namespace TowerDefenseNetworking.Stats
{
    /// <summary>
    /// Stores all monsters stats.
    /// </summary>
    public struct MonsterStats
    {
        public int HP { get; private set; }
        public int Damage { get; private set; }
        public int Speed { get; private set; }
        public int Price { get; private set; }
        public int Reward { get; private set; }
        public string Desc { get; private set; }
        public MonsterStats(int hp,int damage,int speed,int price,int reward,string desc)
        {
            this.HP = hp;
            this.Damage = damage;
            this.Speed = speed;
            this.Price = price;
            this.Reward = reward;
            this.Desc = desc;
        }
    }
}
