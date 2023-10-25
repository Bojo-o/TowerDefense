using System.Collections.Generic;
using System.Drawing;
using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseClient
{
    /// <summary>
    /// Represent game map on the client side. It stores the whole map, provides methods
    /// which edit the game map.
    /// </summary>
    public class GameMap
    {
        private readonly Game _game;
        /// <summary>
        /// Whole map stored in two dim array.
        /// </summary>
        private readonly Tile[,] _map;
        /// <summary>
        /// Stores existing towers in the game. Its indexed by location, where should tower exists.
        /// </summary>
        private readonly Dictionary<TowerDefenseNetworking.Point, Tower> _towersDict = new Dictionary<TowerDefenseNetworking.Point, Tower>();
        /// <summary>
        /// Size of game square tile.
        /// </summary>
        /// <remarks>
        /// On the both sides, the server, the client must be assing same value, for nice rendering.
        /// </remarks>
        public static int TileSize = 64;
        public int MapHeight { get; private set; }
        public int MapWidth { get; private set; }
        /// <summary>
        /// For each kind of tower it stores color of range circle, which is rendered aroud the tower,
        /// what represent tower range.
        /// </summary>
        private static readonly Dictionary<TowerTypes, Color> _towerRangeColors = new Dictionary<TowerTypes, Color>();
        /// <summary>
        /// For each kind of tower , it stores sprite image, which is then rendered.
        /// </summary>
        private static readonly Dictionary<TowerTypes, Bitmap> _towersSprites = new Dictionary<TowerTypes, Bitmap>();
        static GameMap()
        {
            _towersSprites.Add(TowerTypes.Archer, Properties.Resources.ArcherTower);
            _towersSprites.Add(TowerTypes.Turret, Properties.Resources.TurretTower);
            _towersSprites.Add(TowerTypes.Ice, Properties.Resources.IceTower);
            _towersSprites.Add(TowerTypes.Canon, Properties.Resources.CanonTower);
            _towersSprites.Add(TowerTypes.Fire, Properties.Resources.FireTower);
            _towersSprites.Add(TowerTypes.Air, Properties.Resources.AirTower);
            _towersSprites.Add(TowerTypes.AirTurret, Properties.Resources.AirTurretTower);
            _towersSprites.Add(TowerTypes.Wind, Properties.Resources.WindTower);
            _towersSprites.Add(TowerTypes.Storm, Properties.Resources.StormTower);
            _towersSprites.Add(TowerTypes.Poison, Properties.Resources.PoisonTower);
            _towersSprites.Add(TowerTypes.Explode, Properties.Resources.ExplodeTower);

            _towerRangeColors.Add(TowerTypes.Archer, Color.Brown);
            _towerRangeColors.Add(TowerTypes.Turret, Color.SandyBrown);
            _towerRangeColors.Add(TowerTypes.Ice, Color.WhiteSmoke);
            _towerRangeColors.Add(TowerTypes.Canon, Color.DarkGray);
            _towerRangeColors.Add(TowerTypes.Fire, Color.DarkRed);
            _towerRangeColors.Add(TowerTypes.Air, Color.Blue);
            _towerRangeColors.Add(TowerTypes.AirTurret, Color.BlueViolet);
            _towerRangeColors.Add(TowerTypes.Wind, Color.LightGray);
            _towerRangeColors.Add(TowerTypes.Storm, Color.Yellow);
            _towerRangeColors.Add(TowerTypes.Poison, Color.GreenYellow);
            _towerRangeColors.Add(TowerTypes.Explode, Color.Black);
        }
        /// <summary>
        /// From game map representation , it create he entire game map.
        /// </summary>
        /// <param name="game">Game on client side</param>
        /// <param name="dataOfMap">two dim array, received from the server, which provides whole game map representation</param>
        public GameMap(Game game, TileTypes[,] dataOfMap)
        {
            this._game = game;
            MapHeight = dataOfMap.GetLength(0);
            MapWidth = dataOfMap.GetLength(1);
            _map = new Tile[MapHeight, MapWidth];

            int y = 0;
            int x = 0;
            foreach (var tile in dataOfMap)
            {              
                switch (tile)
                {
                    case TileTypes.GlassA:
                        _map[y, x] = new Tile(new TowerDefenseNetworking.Point { X=x, Y=y}, Properties.Resources.Grass, PlayerID.PlayerA,UITypes.Towers);
                        break;
                    case TileTypes.GlassB:
                        _map[y, x] = new Tile(new TowerDefenseNetworking.Point { X = x, Y = y }, Properties.Resources.Grass, PlayerID.PlayerB, UITypes.Towers);
                        break;
                    case TileTypes.Dirt:
                        _map[y, x] = new Tile(new TowerDefenseNetworking.Point { X = x, Y = y }, Properties.Resources.Dirt, PlayerID.None, UITypes.None);
                        break;
                    case TileTypes.StartPointA:
                        _map[y, x] = new Tile(new TowerDefenseNetworking.Point { X = x, Y = y }, Properties.Resources.StartPoint, PlayerID.PlayerB, UITypes.Monsters);
                        break;
                    case TileTypes.StartPointB:
                        _map[y, x] = new Tile(new TowerDefenseNetworking.Point { X = x, Y = y }, Properties.Resources.StartPoint, PlayerID.PlayerA, UITypes.Monsters);
                        break;
                    case TileTypes.EndPoint:
                        _map[y, x] = new Tile(new TowerDefenseNetworking.Point { X = x, Y = y }, Properties.Resources.EndPoint,PlayerID.None, UITypes.None);
                        break;
                    case TileTypes.Barricade:
                        _map[y, x] = new Tile(new TowerDefenseNetworking.Point { X = x, Y = y }, Properties.Resources.Barricade, PlayerID.None, UITypes.None);
                        break;
                }

                x++;
                if (x == MapWidth)
                {
                    x = 0;
                    y++;
                }
            }
        }
        /// <summary>
        /// Help method to indicates if the tile exists at certain location.
        /// </summary>
        /// <param name="grid">location of the game tile</param>
        /// <returns>true if at this location exists tile in game map</returns>
        public bool ExistTileAtGrid(TowerDefenseNetworking.Point grid)
        {
            return 0 <= grid.Y && grid.Y < (int)MapHeight && 0 <= grid.X && grid.X < (int)MapWidth;

        }
        /// <summary>
        /// From map obtain the certain tile at certain location.
        /// </summary>
        /// <param name="grid">location of tile</param>
        /// <returns>obtained tile entity</returns>
        public Tile GetTileAt(TowerDefenseNetworking.Point grid)
        {
            return _map[grid.Y, grid.X];
        }
        /// <summary>
        /// Get tower entity from the game map.
        /// </summary>
        /// <param name="grid">location of tower</param>
        /// <returns>the tower entity if the tower exists at this location, otherwise null</returns>
        public Tower GetTowerAt(TowerDefenseNetworking.Point grid)
        {
            if (_towersDict.TryGetValue(grid, out Tower tower))
            {
                return tower;
            }
            return null;           
        } 
        /// <summary>
        /// Destroy tower, which will be replaced by empty tile, representing space for a new tower to be built. 
        /// </summary>
        /// <param name="action">tower action, obtains location of the tower,
        /// which will be replaced for a game tile, representing empty space for tower
        /// </param>
        public void DestroyTower(TowerAction action)
        {
            _map[action.Location.Y, action.Location.X] = new Tile(action.Location, Properties.Resources.Grass,action.PlayerID,UITypes.Towers);       
            _towersDict.Remove(action.Location);
        }
        /// <summary>
        /// Upgrades the tower stats.
        /// </summary>
        /// <param name="action">tower action, obtains location of the upgraded tower</param>
        public void UpgradeTower(TowerAction action)
        {
            _towersDict.TryGetValue(action.Location, out Tower tower);
            tower.Upgrade();
        }
        /// <summary>
        /// Build a new tower, so empty tile space is replaced by tower.
        /// </summary>
        /// <param name="action">tower action, obtains location and type of tower, which will be built</param>
        public void BuildTower(TowerAction action)
        {         
            _towersSprites.TryGetValue(action.TowerType, out Bitmap towerSprite);
            _game.TowersStatsDict.TryGetValue(action.TowerType, out TowerStats towerStats);
            _map[action.Location.Y, action.Location.X] = new Tile(action.Location, towerSprite, action.PlayerID, UITypes.Upgrade);
            var rangeCircle = CreateNewRangeCircle(action.TowerType, action.Location);
            _towersDict.Add(action.Location, new Tower(action.TowerType,towerStats,rangeCircle));
        }
        /// <summary>
        /// Draw on window the whole game map and ranges circles around towers.
        /// </summary>
        /// <param name="g">graphisc,be able to draws game map</param>
        public void Draw(Graphics g)
        {
            for (byte y = 0; y < MapHeight; y++)
            {
                for (byte x = 0; x < MapWidth; x++)
                {
                    _map[y, x].Draw(g);
                }
            }
            foreach(var item in _towersDict)
            {
                item.Value.RangeCircle.Draw(g);
            }
        }
        /// <summary>
        /// Create a new range circle radius, which is rendered around tower in the game map.
        /// </summary>
        /// <param name="typeOfTower">type of tower, to know which color used for circle range</param>
        /// <param name="gridLocation">location to know around which tile/Tower it creates a new range circle</param>
        /// <returns>a new tower range circle radius</returns>
        private TowerRangeCircle CreateNewRangeCircle(TowerTypes typeOfTower, TowerDefenseNetworking.Point gridLocation)
        {
            _game.TowersStatsDict.TryGetValue(typeOfTower, out TowerStats towerStats);
            _towerRangeColors.TryGetValue(typeOfTower, out Color circleColor);
            return new TowerRangeCircle(towerStats.Range, circleColor, new TowerDefenseNetworking.Point
            {
                X = (gridLocation.X * TileSize) + TileSize / 2,
                Y = (gridLocation.Y * TileSize) + TileSize / 2
            });
        }
    }
}
