using System.Collections.Generic;
using System.Linq;
using TowerDefenseServer.Tiles.Towers;
using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;

namespace TowerDefenseServer.Monsters
{
    /// <summary>
    /// The monster representation on the server side. It provides methods for monster movement
    /// and processing attacks from towers.
    /// </summary>
    /// <remarks>
    /// It inherit from the interface, for all towers type attacks.
    /// So this abstract object implements all these methods but acts as if it ignoring all the attacks.
    /// Concrate monsters, which inherit from this object must implements that tower attack methods,
    /// which have an effect on them.
    /// </remarks>
    public abstract class Monster : ITowerAttacks
    {
        public Point GridLocation { get; protected set; }
        public Point Location { get; protected set; }
        public int FullHP { get; protected set; }
        public int CurrHP { get; protected set; }
        public int Damage { get; protected set; }
        public int MovementSpeed { get; protected set; }
        /// <summary>
        /// How much golds player gets if it kills that monster.
        /// </summary>
        public int Reward { get; protected set; }
            
        private GameMap _gameMap;
        private MovementDirection _direction = MovementDirection.NONE;
        private int _tileSize;
        private static readonly Dictionary<MovementDirection,Point> _posibbleDirections;
        private static readonly List<MovementDirection> _opositeDirections;
        private bool _isInInsideTileMovement = false;
        private int _remainingPixelsToMove;
        private bool _isSlowed = false;
        private Percentage _slowness = new Percentage(0);
        static Monster(){
            _posibbleDirections = new Dictionary<MovementDirection, Point>
            {
                { MovementDirection.DOWN, new Point { X = 0, Y = 1 } },
                { MovementDirection.RIGHT, new Point { X = 1, Y = 0 } },
                { MovementDirection.LEFT, new Point { X = -1, Y = 0 } },
                { MovementDirection.UP, new Point { X = 0, Y = -1 } }
            };

            _opositeDirections = new List<MovementDirection>
            {
                MovementDirection.DOWN,
                MovementDirection.UP,
                MovementDirection.LEFT,
                MovementDirection.RIGHT
            };
        }
        /// <summary>
        /// Sets the monsters properties.
        /// </summary>
        /// <param name="gameMap">game map, the monster must knows game map to be able to moved</param>
        /// <param name="stats">monster stats such as damage, movement speed..</param>
        /// <param name="gridLocation">location, in which tile is the monster located</param>
        /// <param name="tileSize">size of tile, so the monster knows if already moves one tile</param>
        public void SetMonsterPropetries(GameMap gameMap,MonsterStats stats,Point gridLocation,int tileSize)
        {
            this._gameMap = gameMap;
            this._tileSize = tileSize;
            this.GridLocation = new Point { X = gridLocation.X, Y = gridLocation.Y };
            this.Location = new Point { X = gridLocation.X * tileSize, Y = gridLocation.Y * tileSize };
            this.FullHP = stats.HP;
            this.CurrHP = stats.HP;
            this.Damage = stats.Damage;
            this.MovementSpeed = stats.Speed;
            this.Reward = stats.Reward;
        }
        /// <summary>
        /// If the monster needs find a new direction, it must be able to not move same way as it comes.
        /// This is helping methods for resolving that problem.
        /// </summary>
        /// <param name="direction">direction</param>
        /// <returns>the opposite direction from the specified one</returns>
        private MovementDirection GetOpositeDirection(MovementDirection direction)
        {
            if (direction == MovementDirection.NONE)
            {
                return MovementDirection.NONE;
            }
            return _opositeDirections.ElementAt((int)direction - 1);
        }
        /// <summary>
        /// Check if the monster can move in this direction.
        /// </summary>
        /// <param name="direction">direction for movement</param>
        /// <returns>true if the monster can move that direction</returns>
        private bool NextDirectionPossibility(Point direction)
        {
            return _gameMap.IsTileTransitional(new Point {X = GridLocation.X + direction.X, Y = GridLocation.Y + direction.Y });
        }
        /// <summary>
        /// If the monster can not move it direction anymore, it finds out a new direction for movement.
        /// </summary>
        /// <returns>a new direction, in which monster can move</returns>
        private bool DecideNextDirection()
        {
            foreach(KeyValuePair<MovementDirection, Point> direction in _posibbleDirections)
            {
                if (NextDirectionPossibility(direction.Value) && this._direction!= GetOpositeDirection(direction.Key))
                {
                    this.GridLocation = new Point {
                        X=this.GridLocation.X + direction.Value.X,
                        Y=this.GridLocation.Y + direction.Value.Y
                    };
                    this._direction = direction.Key;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Moves the monster in direction, in which it is.
        /// </summary>
        /// <param name="pixelsToMove">value of how many pixels will be the monster moved</param>
        private void MoveInDirection(int pixelsToMove)
        {
            _posibbleDirections.TryGetValue(_direction, out Point moveDirectionPoint);          
            Location = new Point {
                X = Location.X + (moveDirectionPoint.X * pixelsToMove),
                Y = Location.Y + (moveDirectionPoint.Y * pixelsToMove)
            };
        }
        /// <summary>
        /// Indicates, whether the monster is still alive.
        /// </summary>
        /// <returns>true if monster is alive, that means ,it has still some HP</returns>
        public bool IsAlive()
        {
            return CurrHP > 0;
        }
        /// <summary>
        /// The monster will move, the monster knows game map, so it knows where to move.      
        /// </summary>
        ///<remarks>
        /// If monster is effected by slowness effect, it will move less and turns off that efect.
        /// But if monster is in the range of the tower, which slows down, it turns up again slowness effect.
        /// </remarks>
        /// <returns>true if the monster moved, it serves as a finding that the monster is already at the end,
        /// bacase then it can not move.
        /// </returns>
        public bool Move()
        {
            int pixelsToMove = MovementSpeed;

            if (_isSlowed)
            {
                _isSlowed = false;
                pixelsToMove -= (int)((double)MovementSpeed * (double)_slowness.Value / 100.0);
            }

            if (_isInInsideTileMovement)
            {
                if (_remainingPixelsToMove <= pixelsToMove)
                {
                    _isInInsideTileMovement = false;
                    MoveInDirection(_remainingPixelsToMove);                   
                }
                else
                {
                    _remainingPixelsToMove -= pixelsToMove;
                    MoveInDirection(pixelsToMove);
                }
            }
            else
            {
                if (!DecideNextDirection())
                {
                    return false;
                }
                _isInInsideTileMovement = true;
                _remainingPixelsToMove = _tileSize - pixelsToMove;
                MoveInDirection(pixelsToMove);
            }
            return true;
        }
        /// <summary>
        /// Help method, for wraping the monster information for creating render info for the client.
        /// </summary>
        /// <returns>monster info for rendering</returns>
        protected MonsterRenderInfo PrepareRenderInfo()
        {
            return new MonsterRenderInfo { Location = new Point { X = Location.X, Y = Location.Y },
                RemainingHP = new Percentage((int)(((double)CurrHP / (double)FullHP) * 100.0))
            };
        }
        /// <summary>
        /// Wrap necessery info about the monster, which the client needs for render that monster on the screen.
        /// </summary>
        /// <returns>Render info for the client to know renders monsters</returns>
        public abstract MonsterRenderInfo GetMonsterRenderInfo();
        /// <summary>
        /// The monster will be slower, that means for the next move ,it will move less.
        /// </summary>
        /// <param name="value">% value of how much will be the monster slower</param>
        public void DealSlowness(Percentage value)
        {
            _isSlowed = true;
            _slowness = value;
        }
        /// <summary>
        /// Takes monster damage by provided value.
        /// </summary>
        /// <param name="value">damage value given to the monster</param>
        public void DealDamage(int value)
        {
            this.CurrHP -= value;
        }
        public virtual bool TowerAttack(AirTower tower)
        {
            return false;
        }
        public virtual bool TowerAttack(AirTurretTower tower)
        {
            return false;
        }
        public virtual bool TowerAttack(ArcherTower tower)
        {
            return false;
        }
        public virtual bool TowerAttack(CanonTower tower)
        {
            return false;
        }
        public virtual bool TowerAttack(ExplodeTower tower)
        {
            return false;
        }
        public virtual bool TowerAttack(FireTower tower)
        {
            return false;
        }
        public virtual bool TowerAttack(IceTower tower)
        {
            return false;
        }
        public virtual bool TowerAttack(PoisonTower tower)
        {
            return false;
        }

        public virtual bool TowerAttack(StormTower tower)
        {
            return false;
        }

        public virtual bool TowerAttack(TurretTower tower)
        {
            return false;
        }

        public virtual bool TowerAttack(WindTower tower)
        {
            return false;
        }
    }
}
