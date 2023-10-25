namespace TowerDefenseNetworking.Stats
{
    /// <summary>
    /// Concrate Upgrader, which works at based on the ratio.
    /// </summary>
    public class TowerUpgraderRatio : ITowerUpgrader
    {     
        private readonly double _ratio;
        /// <summary>
        /// Init ratio value.
        /// </summary>
        /// <param name="ratio">ratio value</param>
        public TowerUpgraderRatio(double ratio)
        {
            this._ratio = ratio;
        }
        /// <summary>
        /// Upgrade tower stats based on multiplication.
        /// </summary>
        /// <param name="stats"></param>
        /// <returns>new upgraded tower stats</returns>
        public TowerStats Upgrade(TowerStats stats)
        {
            var newDamage = stats.Damage + (int)(stats.Damage * _ratio);
            var newRange = stats.Range + (int)(stats.Range * _ratio / 2);
            var newSpeed = stats.Speed - (int)(stats.Speed * _ratio / 3);
            var newSellPrice = stats.SellPrice + (int)(stats.SellPrice * _ratio / 4);
            var newUpgradePrice = stats.UpgradePrice + (int)(stats.UpgradePrice * _ratio / 3);
            var newLevel = stats.TowerLevel + 1;

            return new TowerStats(newDamage, newRange, newSpeed, stats.BuildPrice, newSellPrice, newUpgradePrice,newLevel,stats.TowerMaxLevel, _ratio,stats.Desc);
        }
    }
}
