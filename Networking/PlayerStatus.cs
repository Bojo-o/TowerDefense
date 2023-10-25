namespace TowerDefenseNetworking
{
    /// <summary>
    /// Stores player info , which the client needs to display it in the game.
    /// </summary>
    public struct  PlayerStatus
    {
        public int HP { get; set; }
        public int EnemyHP { get;  set; }
        public int Gold { get;  set; }
    }
}
