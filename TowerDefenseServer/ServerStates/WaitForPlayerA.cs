using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.ServerStates
{
    /// <summary>
    /// Concrate state of server, representing that the server is waiting for the first player to connect.
    /// </summary>
    class WaitForPlayerA : IServerState
    {
        /// <summary>
        /// Create a new connection with client and gives him playerA ID.
        /// </summary>
        public void DoAction(Server server)
        {
            server.CreateConnection(PlayerID.PlayerA);
            server.SetServerState(new WaitForPlayerB());
        }
    }
}
