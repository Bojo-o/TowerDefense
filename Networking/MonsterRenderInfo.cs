using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseNetworking
{
    /// <summary>
    /// Struct, which the server sends over the network to let know the client 
    /// necessary info about monster, to be able render monster in the game.
    /// </summary>
    public struct MonsterRenderInfo
    {
        /// <summary>
        /// Type of monster, so the clients know which Image to used for this monster.
        /// </summary>
        public MonsterTypes MonsterType { get; set; }
        /// <summary>
        /// Inform how many HP has monster , so the client is able to draw HealtBar status above monster.
        /// </summary>
        public Percentage RemainingHP { get; set; }
        /// <summary>
        /// Location of where is the monster in game, the clients know where render monster.
        /// </summary>
        public Point Location { get; set; }
    }
}
