namespace TowerDefenseNetworking.Stats
{
    /// <summary>
    /// Provides interface to be able check if tower stats can be upgraded in the state they are in.
    /// </summary>
    public interface ITowerUpgradeChecker
    {
        bool Check(TowerStats stats);
    }
}
