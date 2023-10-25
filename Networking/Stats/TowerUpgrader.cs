namespace TowerDefenseNetworking.Stats
{
    /// <summary>
    /// Provides interface to upgrade tower stats.
    /// </summary>
    public interface ITowerUpgrader
    {
        TowerStats Upgrade(TowerStats stats);
    }
}
