using TowerDefenseNetworking;

namespace TowerDefenseServer.Tiles
{
    /// <summary>
    /// Represent game tile , which is solid, what means monsters can not travel over it.
    /// </summary>
    public class Tile
    {
        public bool IsTransitional { get; protected set; } = false;
        public virtual void Action(Game game, TowerAction action)
        {

        }
    }
}
