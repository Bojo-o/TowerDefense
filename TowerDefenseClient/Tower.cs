using TowerDefenseNetworking.TypeEnums;
using TowerDefenseNetworking.Stats;

namespace TowerDefenseClient
{
    /// <summary>
    /// Game enity, which represent tower.
    /// </summary>
    public class Tower
    {
        /// <summary>
        /// Towers stats.
        /// </summary>
        public TowerStats Stats;
        /// <summary>
        /// Tower range circle radius.
        /// </summary>
        public TowerRangeCircle RangeCircle { get; private set; }
        /// <summary>
        /// Type of tower, which indicates what kind of tower it is.
        /// </summary>
        public TowerTypes TowerType { get; private set; }
        /// <summary>
        /// Checker if tower stats can be upgraded.    
        /// </summary>
        public TowerUpgradeCheckerLevel TowerUpgradeCheckerLevel { get; private set; }
        /// <summary>
        /// Upgader, which know how to upgrade tower stats.
        /// </summary>
        public TowerUpgraderRatio TowerUpgraderRatio { get; private set; }
        /// <summary>
        /// Assing Tower properties.
        /// </summary>
        /// <param name="towerType">Type of tower</param>
        /// <param name="towerStats">Certain tower stats</param>
        /// <param name="towerRangeCircle">Range circle, which is around the tower</param>
        public Tower(TowerTypes towerType,TowerStats towerStats, TowerRangeCircle towerRangeCircle)
        {
            this.Stats = towerStats;
            this.RangeCircle = towerRangeCircle;
            this.TowerUpgradeCheckerLevel = new TowerUpgradeCheckerLevel(towerStats.TowerMaxLevel);
            this.TowerUpgraderRatio = new TowerUpgraderRatio(towerStats.UpgradeRatio);
            this.TowerType = towerType;
            this.RangeCircle = towerRangeCircle;
        }
        /// <summary>
        /// If tower can be upgraded it Upgrades it, by stats upgradtions.
        /// </summary>
        public void Upgrade()
        {
            if (Stats.Upgrade(TowerUpgradeCheckerLevel, TowerUpgraderRatio))
            {
                RangeCircle.UpdateRangeValue(this.Stats.Range);
            }
        }
    }
}
