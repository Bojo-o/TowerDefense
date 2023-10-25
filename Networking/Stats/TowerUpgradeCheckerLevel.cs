namespace TowerDefenseNetworking.Stats
{
    /// <summary>
    /// Concrate Checker, which it works on the tower lever check.
    /// </summary>
    public class TowerUpgradeCheckerLevel : ITowerUpgradeChecker
    {
        private readonly int _maxLevel;
        /// <summary>
        /// Assing max level.
        /// </summary>
        /// <param name="maxLevel">max level of tower</param>
        public TowerUpgradeCheckerLevel(int maxLevel)
        {
            this._maxLevel = maxLevel;
        }
        /// <summary>
        /// Check if tower is already at a maximum level.
        /// </summary>
        /// <param name="stats">Tower stats</param>
        /// <returns>true if the stats can be upgraded</returns>
        public bool Check(TowerStats stats)
        {
            return stats.TowerLevel < _maxLevel;
        }
    }
}
