using TowerDefenseNetworking;

namespace TowerDefenseServer.Monsters
{
    /// <summary>
    /// Interface for creating monsters.
    /// </summary>
    public interface IMonsterFactory
    {
        /// <summary>
        /// Create a new monster.
        /// </summary>
        /// <param name="gameMap">game map, when the monster exists , it must move and for it it used game map,
        /// so that it knows where to go</param>
        /// <param name="gridLocation">location, where will be the monster be spawned</param>
        /// <returns>a created monster</returns>
        Monster CreateMonster(GameMap gameMap, Point gridLocation);
    }
}
