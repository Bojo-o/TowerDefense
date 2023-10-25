using TowerDefenseNetworking;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Tiles.Towers
{
    /// <summary>
    /// Interface for creating new towers.
    /// </summary>
    public interface ITowerFactory
    {
        /// <summary>
        /// Create a new tower.
        /// </summary>
        /// <param name="owner">player ID, then the game knows who owns the tower</param>
        /// <param name="gridLocation">location, where the tower will be located</param>
        /// <returns>a new constructed tower</returns>
        Tower CreateTower(PlayerID owner,Point gridLocation);
    }
}
