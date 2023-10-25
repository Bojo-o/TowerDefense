using System;
using System.Threading.Tasks;
using TowerDefenseNetworking;
using TowerDefenseNetworking.TypeEnums;
using System.Collections.Generic;

namespace TowerDefenseServer
{
    /// <summary>
    /// Every clients in server/client architecture gets this object, which
    /// provides abstraction of handling clients requirements on the server side.
    /// </summary>
    /// <remarks>
    /// A new Task is created to listen and process clients requirements sends over the network.
    /// </remarks>
    public class ClientHandler
    {
        private readonly Server _server;
        private CommunicationProtocol clientServerCommunication;
        /// <summary>
        /// Stores actions, which are indexed by type of packet.
        /// When incomming data is processed, based on packet type , it calls suitable
        /// action for next reading and processing of data received from the client.
        /// </summary>
        private readonly Dictionary<PacketTypes, Action> _actionsDict = new Dictionary<PacketTypes, Action>();
        /// <summary>
        /// Each client is assigned an ID, thanks by the server knows identifies
        /// with whom it communicates.
        /// </summary>
        private readonly PlayerID _playerID;
        public ClientHandler(Server server,PlayerID playerID)
        {
            this._playerID = playerID;
            this._server = server;
            InitAction();
        }
        /// <summary>
        /// Start a new Task, in which it will be listening client.
        /// When receives incoming data, then invokes a suitable action.
        /// </summary>
        /// <param name="networkingComunication">Communication connection between the server and the client</param>
        public void StartClient(CommunicationProtocol networkingComunication)
        {
            this.clientServerCommunication = networkingComunication;           
            Task.Run(() => { RunClientListening(); });
        }
        /// <summary>
        /// For all packet types, which the client will be sending,
        /// it creates respective action to process that data.
        /// </summary>
        private void InitAction()
        {
            _actionsDict.Add(PacketTypes.Message, () =>
            {
                try
                {
                    _server.BroadcastMsg(_playerID.ToString() + " : " + clientServerCommunication.ReadMessage());
                }
                catch(Exception)
                {
                    _server.SendClientDisconnection();
                    _server.StopServer();
                }
                
            });

            _actionsDict.Add(PacketTypes.PlayerIsReadyFlag, () =>
             {
                 _server.PlayerIsReady(_playerID);
             });

            _actionsDict.Add(PacketTypes.TowerAction, () =>
            {
                _server.Game.Action(clientServerCommunication.ReadTowerAction());
            });

            _actionsDict.Add(PacketTypes.MonsterAction, () =>
            {
                _server.Game.TryAddMonster(clientServerCommunication.ReadMonsterAction(), _playerID);
            });
        }
        /// <summary>
        /// While loop, running while the server is running, which listens and handle incoming data,that is sends over the network.
        /// </summary>
        private void RunClientListening()
        {
            while (_server.IsServerRunning())
            {
                try
                {                                    
                    if (clientServerCommunication.DataAvailable())
                    {
                        _actionsDict.TryGetValue(clientServerCommunication.GetPacketType(), out Action action);
                        if (action != null)
                        {
                            action.Invoke();
                        }                       
                    }                   
                }
                catch (Exception e)
                {
                    _server.PrintInfo(e.Message);
                    break;                   
                }
            }
        }
    }
}
