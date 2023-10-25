namespace TowerDefenseServer.ServerStates
{
    /// <summary>
    /// Interface for State patter, which uses server for representing it inner state.
    /// </summary>
    public interface IServerState
    {
        /// <summary>
        /// Executed action for current server state.
        /// </summary>
        /// <param name="server">server for its internal manupilation</param>
        void DoAction(Server server);
    }
}
