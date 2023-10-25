using TowerDefenseNetworking;
using TowerDefenseNetworking.TypeEnums;
using TowerDefenseServer.Tiles;

namespace TowerDefenseServer
{
    /// <summary>
    /// Represents a whole game map , which resides on the server side.
    /// It provides methods for changing game map tiles and inform about game map.
    /// </summary>
    /// <remarks>
    /// For monsters it provides methods to knows where they can move.
    /// </remarks>
    public class GameMap
    {
        /// <summary>
        /// Two dim array, that stores game map.
        /// </summary>
        private readonly Tile[,] _map;
        /// <summary>
        /// The server must send over the network game map to players,
        /// this property represents whole game map, which the server sends to clients.
        /// </summary>
        public TileTypes[,] MapRepresentation { get; private set; }
        public byte MapHeight { get; private set; }
        public byte MapWidth { get; private set; }
        /// <summary>
        /// Tile location, where monsters, which player A sends, will be spawned.
        /// </summary>
        public Point StartPositionA { get; private set; }
        /// <summary>
        /// Tile location, where monsters, which player B sends, will be spawned.
        /// </summary>
        public Point StartPositionB { get; private set; }
        /// <summary>
        /// Creates a whole game map.
        /// </summary>
        /// <param name="mapRepresentation">data , which represents a whole game map</param>
        public GameMap(TileTypes[,] mapRepresentation)
        {
            MapHeight = (byte)mapRepresentation.GetLength(0);
            MapWidth = (byte)mapRepresentation.GetLength(1);

            _map = new Tile[MapHeight, MapWidth];
       
            this.MapRepresentation = mapRepresentation;
            for (byte y = 0; y < MapHeight; y++)
            {
                for(byte x = 0;x < MapWidth; x++)
                {
                    switch (mapRepresentation[y,x])
                    {
                        case TileTypes.GlassA:
                            var tileA = new EmptyTowerTile();
                            tileA.SetOwner(PlayerID.PlayerA);
                            _map[y, x] = tileA;
                            break;
                        case TileTypes.GlassB:
                            var tileB = new EmptyTowerTile();
                            tileB.SetOwner(PlayerID.PlayerB);
                            _map[y, x] = tileB;
                            break;
                        case TileTypes.Dirt:
                            _map[y, x] = new TransitionalTile();
                            break;
                        case TileTypes.StartPointA:
                            StartPositionA = new Point { X = x, Y=y };
                            _map[y, x] = new Tile();
                            break;
                        case TileTypes.StartPointB:
                            StartPositionB = new Point { X = x, Y = y };
                            _map[y, x] = new Tile();
                            break;
                        case TileTypes.EndPoint:
                            _map[y, x] = new TransitionalTile();
                            break;
                        case TileTypes.Barricade:
                            _map[y, x] = new Tile();
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// Indicates for monsters, that if they can travel over given tile.
        /// </summary>
        /// <param name="grid">location of certain tile</param>
        /// <returns>true, if tile is transitional</returns>
        public bool IsTileTransitional(Point grid)
        {
            return _map[grid.Y, grid.X].IsTransitional;
        }
        /// <summary>
        /// Indicates existation of game tile at certain location.
        /// </summary>
        /// <param name="grid">location of certain tile</param>
        /// <returns>true, if on the game map exist tile at given location</returns>
        public bool ExistTileAtGrid(Point grid)
        {
            return 0 <= grid.Y && grid.Y < (int)MapHeight && 0 <= grid.X && grid.X < (int)MapWidth;

        }
        /// <summary>
        /// Obtain from the game map the certain tile.
        /// </summary>
        /// <param name="grid">location of certain tile</param>
        /// <returns>the tile, which resides at given location</returns>
        public Tile GetTile(Point grid)
        {
            return _map[grid.Y, grid.X];
        }
        /// <summary>
        /// Replace the tile at the game map for a new one.
        /// </summary>
        /// <param name="tile">a new tile, which will be replaced for the old tile</param>
        /// <param name="grid">location, where at game map will be a change</param>
        public void ChangeTile(Tile tile,Point grid)
        {
            _map[grid.Y, grid.X] = tile;
        }
    }
}
