namespace TowerDefenseServer.Tiles
{
    /// <summary>
    /// Represent game tile, which is transitional, what means monsters can move over it.
    /// </summary>
    public class TransitionalTile : Tile
    {
        public TransitionalTile() { IsTransitional = true; }
    }
}
