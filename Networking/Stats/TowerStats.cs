namespace TowerDefenseNetworking.Stats
{
    /// <summary>
    /// Stores all tower stats.
    /// </summary>
    public struct TowerStats
    {
        public int Damage { get; private set; }
        public int Range { get; private set; }
        /// <summary>
        /// Time in milliseconds, indicates cooldown time for attacks.
        /// </summary>
        public int Speed { get; private set; }
        public int BuildPrice { get; private set; }
        public int SellPrice { get; private set; }
        public int UpgradePrice { get; private set; }
        public int TowerLevel { get; private set; }
        public int TowerMaxLevel { get; private set; }
        public double UpgradeRatio { get; private set; }
        public string Desc { get; private set; }

        public TowerStats(int damage, int range, int speed, int builPrice, int sellPrice, int upgradePrice, int level, int maxLevel, double upgradeRatio,string desc)
        {
            this.Damage = damage;
            this.Range = range;
            this.Speed = speed;
            this.BuildPrice = builPrice;
            this.SellPrice = sellPrice;
            this.UpgradePrice = upgradePrice;
            this.UpgradeRatio = upgradeRatio;
            this.TowerMaxLevel = maxLevel;
            this.TowerLevel = level;
            this.Desc = desc;
        }
        /// <summary>
        /// Upgrade stats.
        /// </summary>
        /// <param name="checker">Concrate checker to check if stats can be upgraded</param>
        /// <param name="upgrader">Concrate upgrader to upgrade tower stats</param>
        /// <returns>new upgraded tower stats</returns>
        public bool Upgrade(ITowerUpgradeChecker checker, ITowerUpgrader upgrader)
        {
            if (checker.Check(this))
            {

                this = upgrader.Upgrade(this);

                return true;
            }
            return false;
        }
    }
}
