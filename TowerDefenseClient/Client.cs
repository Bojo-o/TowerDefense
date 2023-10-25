using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseClient
{
    /// <summary>
    /// Represents client in the server(TCP Listener)/client(TCP Client) architecture.
    /// Provides methods for communication with the server and also listens for incoming data ,which 
    /// are sent from the server.
    /// </summary>
    class Client
    {
        /// <summary>
        /// Client connection to the server.
        /// From it will be obtained Network Stream, which 
        /// is used as communication bridge between client and server.
        /// </summary>
        private readonly TcpClient _client;
        /// <summary>
        /// WinForm, represents form in which the game is rendering,
        /// it also processes player inputs.
        /// </summary>
        private readonly ClientForm _clientForm;
        private readonly Game _game;
        private CommunicationProtocol _communication;
        /// <summary>
        /// Stores actions, which are indexed by type of packet.
        /// When incomming data is processed, based on packet type , it calls suitable
        /// action for next reading and processing of data received from the server.
        /// </summary>
        private readonly Dictionary<PacketTypes, Action> _actionsDict = new Dictionary<PacketTypes, Action>();
        /// <summary>
        /// For all tower types, it stores their stats.
        /// </summary>
        private readonly Dictionary<TowerTypes, TowerStats> _towersStatsDict = new Dictionary<TowerTypes, TowerStats>();
        /// <summary>
        /// For all monsters in game, it stores their stats.
        /// </summary>
        private readonly Dictionary<MonsterTypes, MonsterStats> _monsterStatsDict = new Dictionary<MonsterTypes, MonsterStats>();
        public bool IsClientRunning { get; private set; }
        public bool IsPlayerReady;

        /// <summary>
        /// Assing game and client winform.
        /// </summary>
        /// <param name="game">Game on client side</param>
        /// <param name="clientForm">WinForm, we need be able to notify client form for display messages from the server </param>
        public Client(Game game,ClientForm clientForm)
        {
            this._game = game;
            this._clientForm = clientForm;
            _client = new TcpClient();
            IsClientRunning = false;
            IsPlayerReady = false;
        }
        /// <summary>
        /// Check connection with the server.
        /// </summary>
        /// <returns>true if client is still connected to the server</returns>
        private bool CheckConncection() {
            try
            {
                _communication.SendFlag(PacketTypes.Connection);
            }
            catch (Exception)
            {

            }
            if (!_client.Connected)
            {
                IsClientRunning = false;
                _game.ServerDisconection();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Send flag to the server over the communication bridge.
        /// </summary>
        /// <param name="packetType">Type of packet,which client needs to be sent to the server</param>
        public void SendFlag(PacketTypes packetType)
        {
            if (CheckConncection())
            {
                _communication.SendFlag(packetType);
            }           
        }
        /// <summary>
        /// Send monster action to the server over network.
        /// </summary>
        ///  <remarks>
        /// When player want buy some kind of monster,which
        /// he wants to send to attack enemy player, client send
        /// monster action to the server and wait for confirmation from server.
        /// Server send same packet, which means for client, that player bought and sent a monster.
        /// </remarks>
        /// <param name="type"></param>
        public void SendMonsterAction(MonsterTypes type)
        {                   
            if (CheckConncection())
            {
                _communication.SendMonsterAction(type);
            }
        }
        /// <summary>
        /// Client send to the server information, that player would like to upgrade.
        /// his tower.
        /// </summary>
        /// <remarks>
        /// If the server evaluate that player is able (tower can be upgraded and player has enough golds)to upgrade his tower,
        /// then server send same packet over the network to confirm that action.
        /// </remarks>
        public void SendTowerActionUpgrade()
        {
            var tower = _game.GameMap.GetTowerAt(_game.ClickedGrid);
            if (tower != null)
            {
                if (CheckConncection())
                {
                    SendTowerAction(tower.TowerType, TowerActionTypes.Upgrade);
                }              
            }            
        }
        /// <summary>
        /// Client send to the server information , that player would like to sell his tower.
        /// </summary>
        /// <remarks>
        /// Works on the same principle as Upgrade action.
        /// </remarks>
        public void SendTowerActionSell()
        {
            var tower = _game.GameMap.GetTowerAt(_game.ClickedGrid);
            if (tower != null)
            {
                if (CheckConncection())
                {
                    SendTowerAction(tower.TowerType, TowerActionTypes.Destroy);
                }               
            }
            
        }
        /// <summary>
        /// Client send
        /// </summary>
        /// <remarks>
        /// Works on the same principle as Upgrade action.
        /// </remarks>
        /// <param name="towerType">Describes type of tower, which player want to built</param>
        public void SendTowerActionBuild(TowerTypes towerType)
        {
            if (CheckConncection())
            {
                SendTowerAction(towerType, TowerActionTypes.Build);
            }            
        }
        /// <summary>
        /// Client send to the server text message over the network.
        /// </summary>
        /// <remarks>
        /// The server then broadcastly send the message to both of players.
        /// For game chat between two players.
        /// </remarks>
        /// <param name="msg">text message</param>
        public void SendMessage(string msg)
        {
            if (CheckConncection())
            {
                _communication.SendMessage(msg);
            }           
        }
        /// <summary>
        /// Try to connect to the server,
        /// if it succeeds then it creates communication bridge
        /// between the client and the server.
        /// </summary>
        /// <remarks>
        /// Also it create new task, in which will be running
        /// while loop for receiving data from the server.
        /// </remarks>
        /// <param name="host">host,which is IP adress where the server is running</param>
        /// <param name="port">port, on which the server listen</param>
        public void Connect(IPAddress host,Int32 port)
        {
            try
            {
                _client.Connect(host, port);
                _clientForm.AppendToInfo("Conneted to server");                
                IsClientRunning = true;
                _communication = new CommunicationProtocol(_client);
                Task.Run(RunClient);           
            }catch(Exception e)
            {
                _clientForm.AppendToInfo(e.Message);
                _clientForm.ResetClient();
            }
        }
        /// <summary>
        /// For all packet types, which the server will be sending,
        /// it creates respective action to process that data.
        /// </summary>
        private void InitActions()
        {
            _actionsDict.Add(PacketTypes.Message, () => {
                _clientForm.AppendToInfo(_communication.ReadMessage());
            });

            _actionsDict.Add(PacketTypes.WorldMap, () => {
                _game.LoadMap(new GameMap(_game, _communication.ReadWorldMap()));
            });
            _actionsDict.Add(PacketTypes.StartGameFlag, () => {
                _clientForm.StartGame(_towersStatsDict, _monsterStatsDict);
            });
            _actionsDict.Add(PacketTypes.PlayersStatus, () => {
                _clientForm.UpdatePlayersStatsOnForm(_communication.ReadPlayerState());
            });
            _actionsDict.Add(PacketTypes.TowerAction, () => {
                _game.ProcessTowerAction(_communication.ReadTowerAction());
            });
            _actionsDict.Add(PacketTypes.PlayerID, () => {
                _game.SetPlayerID(_communication.ReadPlayerID());
            });
            _actionsDict.Add(PacketTypes.TowerStats, () => {
                var towerStats = _communication.ReadTowerStats(out TowerTypes towerType);
                _towersStatsDict.Add(towerType, towerStats);
            });
            _actionsDict.Add(PacketTypes.MonstersStats, () => {
                var monsterStats = _communication.ReadMonsterStats(out MonsterTypes monsterType);
                _monsterStatsDict.Add(monsterType, monsterStats);
            });
            _actionsDict.Add(PacketTypes.MonsterState, () => {
                _game.monsterRenderInfos = _communication.ReadMonsterState();
            });
            _actionsDict.Add(PacketTypes.GameEnd, () => {
                _game.EndGame(_communication.ReadGameEndStatus());
            });

            _actionsDict.Add(PacketTypes.ServerIsFull, () => {
                _game.ServerIsFull();
                this.IsClientRunning = false;
            });

            _actionsDict.Add(PacketTypes.Connection, () => {
               
            });

            _actionsDict.Add(PacketTypes.ClientDisconnection, () => {
                _clientForm.AppendToInfo("Other player disconnected");
                this.IsClientRunning = false;
                if (_game.GameIsRunning)
                {
                    _game.EndGame(GameEndStatus.Victory);
                }                
            });
        }
        /// <summary>
        /// While client is running, it creates while loop, in which it listen and if data are available, it
        /// received the data from the network and then calls appropriate action to propagate that data to the game.
        /// </summary>
        private void RunClient()
        {
            InitActions();       
            while (IsClientRunning)
            {
                if (_communication.DataAvailable())
                {
                    if (_actionsDict.TryGetValue(_communication.GetPacketType(), out Action action))
                    {
                        action.Invoke();
                    }
                    else
                    {
                        throw new Exception("Detect invalid Type of packet");
                    }                                       
                }
            }
        }
        /// <summary>
        /// Wrap and create tower action and then send it over the network to the server.
        /// </summary>
        /// <remarks>
        /// This method calls other methods of concrate action and them provides arguments for this method.
        /// </remarks>
        /// <param name="towerType">type of tower</param>
        /// <param name="actionType">type of action, which player caused</param>
        private void SendTowerAction(TowerTypes towerType, TowerActionTypes actionType)
        {
            _communication.SendTowerAction(new TowerAction
            {
                Location = _game.ClickedGrid,
                TowerActionType = actionType,
                TowerType = towerType,
                PlayerID = _game.PlayerID
            });
        }
    }
}
