using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.ServerStates
{
    /// <summary>
    /// Concrate state of server, representing that the server is waiting for the second player to connect.
    /// </summary>
    class WaitForPlayerB : IServerState
    {
        /// <summary>
        /// Create a new connection with client and gives him playerB ID.
        /// </summary>
        public void DoAction(Server server)
        {
            server.CreateConnection(PlayerID.PlayerB);
            server.SetServerState(new ServerIsFull());
        }
    }
}
