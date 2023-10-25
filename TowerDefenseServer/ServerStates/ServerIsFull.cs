namespace TowerDefenseServer.ServerStates
{
    /// <summary>
    /// Concrate state, when two players join to the server.
    /// </summary>
    /// <remarks>
    /// So others clients obtain from the server info, about that the server is full.
    /// </remarks>
    public class ServerIsFull : IServerState
    {
        /// <summary>
        /// It sends info, that the server is full to player, who try to connect to the server.
        /// </summary>
        public void DoAction(Server server)
        {
            server.NotifyClientThatServerIsFull();
        }
    }
}
