using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;
using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;
using TowerDefenseServer.ServerStates;

namespace TowerDefenseServer
{  
    /// <summary>
    /// Represents the server, which handles clients connections,
    /// host the game, handles players actions, updates game like monsters movement, towers/ monsters
    /// collisions. Every game update sends to clients over the network.
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Server is ON means, it listens for TCP connections.
        /// </summary>
        private enum ServerStatus
        {
            OFF, ON
        }
        private ServerStatus _serverStatus;
        private IServerState _stateOfServer;
        private TcpListener _server;
        private TcpClient _clientA;
        private TcpClient _clientB;
        private CommunicationProtocol _communicationWithClientA;
        private CommunicationProtocol _communicationWithClientB;
        private ClientHandler _clientHandlerA;
        private ClientHandler _clientHandlerB;
        private readonly string _gameMapName;
        public ServerForm ServerForm { get; private set; }
        /// <summary>
        /// When player connects to the server, the server must wait for players to be ready. 
        /// This indicates that player A is already ready.
        /// </summary>
        public bool playerAisReady = false;
        /// <summary>
        /// When player connects to the server, the server must wait for players to be ready. 
        /// This indicates that player B is already ready.
        /// </summary>
        public bool playerBisReady = false;

        private bool gameIsRunning = false;
        public Game Game { get; private set;}
        /// <summary>
        /// Stopwatch to measures the game time, its helpful for games cooldowns and for updates of game.
        /// </summary>
        public Stopwatch Clock { get; private set; } = new Stopwatch();
        private long _lastClockTick = 0;
        /// <summary>
        /// How many times per seconds is the game updated.
        /// </summary>
        private const long _delta = 2000 / 64;     
      
        /// <summary>
        /// Create a new server, sets status as OFF.
        /// </summary>
        /// <param name="serverForm">winform of server, the server updates winform properties such as labels ...</param>
        public Server(ServerForm serverForm,string gameMapName)
        {
            this.ServerForm = serverForm;
            _serverStatus = ServerStatus.OFF;
            _gameMapName = gameMapName;
        }
        /// <summary>
        /// Sets inner state of server, whatever the server is waiting for players or is already full.
        /// </summary>
        /// <param name="newState">a new state of the server</param>
        public void SetServerState(IServerState newState)
        {
            this._stateOfServer = newState;
        }
        /// <summary>
        /// Assings that some player is ready for the game.
        /// </summary>
        /// <param name="playerID">player ID, who is ready for the game</param>
        public void PlayerIsReady(PlayerID playerID)
        {
            if (playerID == PlayerID.PlayerA)
            {
                playerAisReady = true;
                PrintInfo("Player A is ready");
                BroadcastMsg("Player A is ready");
            }
            else
            {
                playerBisReady = true;
                PrintInfo("Player B is ready");
                BroadcastMsg("Player B is ready");
            }
        }
        /// <summary>
        /// Indicates if the server is running.
        /// </summary>
        /// <returns>tru if the server is running, listening for connections or processing game</returns>
        public bool IsServerRunning()
        {
            if(_serverStatus != ServerStatus.OFF)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Notify the servers winform for prints this message to server textarea.
        /// </summary>
        /// <param name="msg">text message</param>
        public void PrintInfo(string msg)
        {          
            ServerForm.AppendToServerStatus(msg);
        }
        /// <summary>
        /// Sends to both player text message over the network.
        /// </summary>
        /// <param name="msg">text message</param>
        public void BroadcastMsg(string msg)
        {
            SendMsgData(_communicationWithClientA,msg);
            SendMsgData(_communicationWithClientB,msg);
        } 
        /// <summary>
        /// Sends to player over the communication protocol text message.
        /// </summary>
        /// <param name="communication">communication bridge with the client</param>
        /// <param name="msg">text message</param>
        private void SendMsgData(CommunicationProtocol communication, string msg)
        {
            if (communication != null)
            {
                communication.SendMessage(msg);
            }          
        }

        /// <summary>
        /// Reads the whole game map from file.
        /// </summary>
        /// <param name="path">path, where game map is stored</param>
        /// <returns>representaion of a whole game map</returns>
        private TileTypes[,] ReadMapFromFile()
        {
            string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            startupPath += "/GameMaps/"+ _gameMapName.Replace(" ","") +".txt";

            if (!File.Exists(startupPath))
            {
                throw new Exception("path to map data is invalid");
            }

            var lines = File.ReadAllLines(startupPath);
            var sizes = lines[0].Split(' ');
            var xSize = Byte.Parse(sizes[1]);
            var ySize = Byte.Parse(sizes[0]);

            TileTypes[,] map = new TileTypes[ySize, xSize];
            
            for(int y=1;y< lines.Length; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    int symbol = lines[y].ElementAt(x);
                    map[y-1, x] = (TileTypes)(symbol - 48);
                }                                  
            }
            return map;
        }
        /// <summary>
        /// Sends to both players that the game is over.
        /// </summary>
        /// <param name="defeated">ID of player who loss</param>
        public void SendGameEndBroadcast(PlayerID defeated)
        {
            if (defeated == PlayerID.PlayerA)
            {
                _communicationWithClientA.SendGameEndStatus(GameEndStatus.Defeat);
                _communicationWithClientB.SendGameEndStatus(GameEndStatus.Victory);
            }
            else
            {
                _communicationWithClientA.SendGameEndStatus(GameEndStatus.Victory);
                _communicationWithClientB.SendGameEndStatus(GameEndStatus.Defeat);
            }           
            gameIsRunning = false;
        }
        /// <summary>
        /// Sends to both clients info about tower action, that means some tower was builded, upgraded or destroyed.
        /// </summary>
        /// <param name="action">stores info about tower action such as location..</param>
        public void SendTowerActionBroadcast(TowerAction action)
        {
            _communicationWithClientA.SendTowerAction(action);
            _communicationWithClientB.SendTowerAction(action);
        }
        /// <summary>
        /// Sends to both players their stats like HP , golds value and enemy players HP.
        /// </summary>
        public void SendPlayerStatsBroadcast() 
        {
            _communicationWithClientA.SendPlayerState(new PlayerStatus { HP = Game.PlayerA.HP,Gold = Game.PlayerA.Gold,EnemyHP = Game.PlayerB.HP});
            _communicationWithClientB.SendPlayerState(new PlayerStatus { HP = Game.PlayerB.HP, Gold = Game.PlayerB.Gold, EnemyHP = Game.PlayerA.HP });
        }
        /// <summary>
        /// Sends to both player render info of monsters, so clients know render monsters on the screen.
        /// </summary>
        /// <param name="listOfMonsters">render information of each monster</param>
        public void SendMonstersStateBroadcast(List<MonsterRenderInfo> listOfMonsters)
        {
            _communicationWithClientA.SendMonstersState(listOfMonsters);
            _communicationWithClientB.SendMonstersState(listOfMonsters);
        }
        /// <summary>
        /// Sends to both players all towers stats.
        /// </summary>
        public void SendTowerStatsBroadcast()
        {
            foreach(KeyValuePair<TowerTypes,TowerStats> item in Game.TowerStatsDict)
            {
                _communicationWithClientA.SendTowerStats(item.Key, item.Value);
                _communicationWithClientB.SendTowerStats(item.Key, item.Value);
            }               
        }
        /// <summary>
        /// Sends to both players all monsters stats.
        /// </summary>
        public void SendMonsterStatsBroadcast()
        {
            foreach (KeyValuePair<MonsterTypes, MonsterStats> item in Game.MonsterStatsDict)
            {
                _communicationWithClientA.SendMonsterStats(item.Key, item.Value);
                _communicationWithClientB.SendMonsterStats(item.Key, item.Value);
            }
        }
        /// <summary>
        /// Sends info to players that some clients was disconnected, the server lost connection with it.
        /// </summary>
        public void SendClientDisconnection()
        {
            TrySendClientDisconnection(_communicationWithClientA);
            TrySendClientDisconnection(_communicationWithClientB);
        }
        /// <summary>
        /// Try sends to player info about that some clients was disconnected, it is in try block, because the server not knows
        /// with which player lost connection.
        /// </summary>
        /// <param name="communication">communication bridge with clients, over it the server sends info</param>
        private void TrySendClientDisconnection(CommunicationProtocol communication)
        {
            try
            {
                communication.SendFlag(PacketTypes.ClientDisconnection);               
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// The game loop, which runs in seperatly task on the server.
        /// It updates game and before the game start it send to both players all info like
        /// whole game map , players starting stats , monster and towers stats..
        /// </summary>
        private void ServerGameLoop()
        {
            try
            {
                while (_serverStatus != ServerStatus.OFF)
                {
                    if (_communicationWithClientA != null && _communicationWithClientB != null)
                    {
                        _communicationWithClientA.SendFlag(PacketTypes.Connection);
                        _communicationWithClientB.SendFlag(PacketTypes.Connection);
                    }
                    if (playerAisReady && playerBisReady && Game == null)
                    {
                        gameIsRunning = true;
                        Game = new Game();
                        Game.SetUpServer(this);
                        Game.SetUpPlayers();
                        
                        Game.LoadGameMap(ReadMapFromFile());
                        _communicationWithClientA.SendWorldMap(Game.Map.MapRepresentation);
                        _communicationWithClientB.SendWorldMap(Game.Map.MapRepresentation);
                        _communicationWithClientA.SendPlayerID(PlayerID.PlayerA);
                        _communicationWithClientB.SendPlayerID(PlayerID.PlayerB);
                        SendPlayerStatsBroadcast();
                        SendTowerStatsBroadcast();
                        SendMonsterStatsBroadcast();
                        PrintInfo("Game is starting..");
                        BroadcastMsg("Game is starting..");
                        _communicationWithClientA.SendFlag(PacketTypes.StartGameFlag);
                        _communicationWithClientB.SendFlag(PacketTypes.StartGameFlag);
                    }
                    if (gameIsRunning)
                    {
                        if (!Clock.IsRunning)
                        {
                            Clock.Start();
                        }
                        var time = Clock.ElapsedMilliseconds;
                        if (time - _lastClockTick > _delta)
                        {
                            _lastClockTick = time;
                            Game.UpdateGame();
                            SendPlayerStatsBroadcast();
                        }
                    }      
                }
            }
            catch(Exception e)
            {
                PrintInfo(e.Message);
                SendClientDisconnection();
                StopServer();
            }
                
        }
        /// <summary>
        /// Start the server, starts new task , in which game and server listenings runs.
        /// </summary>
        /// <param name="host">IP adress , where the server is running</param>
        /// <param name="port">port, on which the server listens</param>
        public void StartServer(IPAddress host, Int32 port)
        {
            try
            {
                PrintInfo("Starting server...");
                _server = new TcpListener(host, port);

                _server.Start();
                PrintInfo("Server is running...");

                _serverStatus = ServerStatus.ON;
                PrintInfo("Waiting for two players...");
            }
            catch(Exception e)
            {
                PrintInfo(e.Message);
                return;
            }
            SetServerState(new WaitForPlayerA());
            Task.Run(() => StartListenForConnectionRequests());
            Task.Run(() => ServerGameLoop());
        }
        /// <summary>
        /// Sets server as OFF, which means for both task for game updating and clients connection listening to ends.
        /// </summary>
        public void StopServer()
        {
            _serverStatus = ServerStatus.OFF;           
        }
        /// <summary>
        /// Handle a new client connection.
        /// Start a new client handler, for listening what the client is sending.
        /// </summary>
        /// <param name="client">client connection</param>
        /// <param name="clientHandler">client handler, which reprenest a new client handler</param>
        /// <param name="communicationTunnel">communication bridge, which represents connection the server with the client</param>
        /// <param name="playerID">ID of player, which the client gets</param>
        private void ProcessNewConnection(ref TcpClient client, ref ClientHandler clientHandler, ref CommunicationProtocol communicationTunnel, PlayerID playerID)
        {
            client = _server.AcceptTcpClient();
            communicationTunnel = new CommunicationProtocol(client);
            clientHandler = new ClientHandler(this, playerID);
            clientHandler.StartClient(communicationTunnel);
            PrintInfo(playerID.ToString() + " connected!");
        }
        /// <summary>
        /// Create a new conection with client.
        /// </summary>
        /// <param name="playerID">ID of player, which the new client gets</param>
        public void CreateConnection(PlayerID playerID)
        {
            if (playerID == PlayerID.PlayerA)
            {
                ProcessNewConnection(ref _clientA, ref _clientHandlerA, ref _communicationWithClientA, playerID);
            }
            else
            {
                ProcessNewConnection(ref _clientB,ref _clientHandlerB, ref _communicationWithClientB, playerID);
            }
        }
        /// <summary>
        /// When a new client wants to connect to the server, when server is full, it sends to a new client 
        /// info about that server is full and thed ends communication with client.
        /// </summary>
        public void NotifyClientThatServerIsFull ()
        {
            var otherClient = _server.AcceptTcpClient();
            var communucationWithOtherClient = new CommunicationProtocol(otherClient);
            communucationWithOtherClient.SendMessage("Server is full");
            communucationWithOtherClient.SendFlag(PacketTypes.ServerIsFull);
            CloseConncetion(ref otherClient);
        }
        /// <summary>
        /// Close connection with given client.
        /// </summary>
        /// <param name="client">client, with who the server closes connection</param>
        private void CloseConncetion(ref TcpClient client)
        {
            if (client != null)
            {
                if (client.Connected)
                {
                    client.GetStream().Close();
                    client.Close();
                    client = null;
                }               
            }
        }
        /// <summary>
        /// Listens for pending connection requests from clients and handles them.
        /// </summary>
        /// <remarks>
        /// When it ends  to listening, it closes both connections with players.
        /// </remarks>
        private void StartListenForConnectionRequests()
        {          
            try
            {                
                while (_serverStatus != ServerStatus.OFF)
                {                   
                    if (_server.Pending())
                    {
                        _stateOfServer.DoAction(this);
                    }
                }
            }
            catch(Exception e)
            {
                PrintInfo(e.Message);
            }
            finally
            {
                CloseConncetion(ref _clientA);
                CloseConncetion(ref _clientB);
                _server.Stop();
                PrintInfo("Server stopped");
            }               
        }
    }
}
