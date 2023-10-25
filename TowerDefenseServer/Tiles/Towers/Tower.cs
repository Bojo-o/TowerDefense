using System.Collections.Generic;
using System.Diagnostics;
using TowerDefenseServer.Monsters;
using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Tiles.Towers
{
    /// <summary>
    /// Represents the tower object in the game.Provides methods for upgrading
    /// and destroying towers, indication if monster is in the range of the tower and
    /// processing attack to monsters.
    /// </summary>
    public abstract class Tower : EmptyTowerTile
    {
        private Point _gridLocation;
        private int _tileSize;
        public TowerStats Stats { get; protected set; }
        private TowerUpgradeCheckerLevel _towerUpgradeCheckerLevel;
        private TowerUpgraderRatio _towerUpgraderRatio;
        /// <summary>
        /// After every attack, the tower has cooldown, which must run away before next attack.
        /// </summary>
        private Cooldown _towerCooldown = null;
        /// <summary>
        /// Represents ,whatever the tower can attack only to one targer or to all targets in the range.
        /// </summary>
        protected static bool IsSingleAttacker = false;
        public bool HaveCooldown { get; protected set; } = true; 
        /// <summary>
        /// Sets tower properties
        /// </summary>
        /// <param name="towerStats">tower stats such as range , damage , cooldown...</param>
        /// <param name="gridLocation">location, where the tower resides</param>
        /// <param name="tileSize">size of game tile</param>
        public void SetTowerPropetries(TowerStats towerStats,Point gridLocation,int tileSize)
        {
            this.Stats = towerStats;
            this._gridLocation = gridLocation;
            this._tileSize = tileSize;
            _towerUpgradeCheckerLevel = new TowerUpgradeCheckerLevel(Stats.TowerMaxLevel);
            _towerUpgraderRatio = new TowerUpgraderRatio(Stats.UpgradeRatio);
        }
        /// <summary>
        /// Indicates if the tower can attack.
        /// </summary>
        /// <returns>true, if tower is able to next attack</returns>
        private bool IsTowerReadyAttack()
        {
            if (HaveCooldown)
            {
                if (_towerCooldown.IsReady)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        /// <summary>
        /// Indicates if monster is in the attack range.
        /// </summary>
        /// <param name="monster">the certain monster</param>
        /// <returns>true if monster is in the tower range</returns>
        private bool IsMonsterInRange(Monster monster)
        {
            var towerLocation = new Point { X = _gridLocation.X * _tileSize, Y = _gridLocation.Y * _tileSize};
            return ComputeFunc.GetDistance(monster.Location,towerLocation) <= Stats.Range/2 ;
        }
        /// <summary>
        /// Notify to the monter that this tower is attacking it.
        /// </summary>
        /// <param name="monster">the certain monster</param>
        /// <returns></returns>
        protected abstract bool AttackToMonster(Monster monster);
        /// <summary>
        /// For each monster, which is attacking, it try to attacks it.
        /// </summary>
        /// <remarks>
        /// It process if tower is ready to attack, if the monster is in the attack range and then provides attack.
        /// </remarks>
        /// <param name="monsters">list of all monsters, on which the tower is able to attack</param>
        public void AttackToMonsterArmy(List<Monster> monsters)
        {           
            if (IsTowerReadyAttack())
            {
                foreach (var monster in monsters)
                {
                    if (IsMonsterInRange(monster))
                    {
                        if (AttackToMonster(monster))
                        {
                            _towerCooldown.Start();
                            if (IsSingleAttacker)
                            {
                                return;
                            }
                        }                                              
                    }
                }
            }
        }
        /// <summary>
        /// Set game clock to tower and create a new cooldown for this tower.
        /// </summary>
        /// <param name="gameClock">clock, which measure game time, so it helps the tower cooldown to works right</param>
        public void SetTowerCooldown(Stopwatch gameClock)
        {
            this._towerCooldown = new Cooldown(gameClock, Stats.Speed);
        }
        /// <summary>
        /// Process action from user/player.
        /// </summary>
        /// <remarks>
        /// If player would like to upgrade or destoy this tower, it will processed that action.
        /// For destorying of the tower it destory tower, add gold to player,who sell this tower and notify players about it.
        /// For Upgrading of the tower it try upgrade tower, takes gold to player,who desires upgrade this tower and notify players about it.
        /// </remarks>
        /// <param name="game">game on the server side</param>
        /// <param name="action">tower action, which contains information what player want to do</param>
        public override void Action(Game game, TowerAction action)
        {
            if (action.TowerActionType == TowerActionTypes.Destroy)
            {
                if (TileOwner == action.PlayerID)
                {
                    var player = game.GetPlayer(action.PlayerID);

                    player.GetGolds(Stats.SellPrice);

                    game.DestroyTower(this, action);

                }
            }
            if (action.TowerActionType == TowerActionTypes.Upgrade)
            {
                if (TileOwner == action.PlayerID)
                {
                    if (_towerUpgradeCheckerLevel.Check(Stats))
                    {
                        var player = game.GetPlayer(action.PlayerID);
                        if (player.UseGolds(Stats.UpgradePrice))
                        {
                            var newStats = Stats;
                            newStats.Upgrade(_towerUpgradeCheckerLevel, _towerUpgraderRatio);
                            Stats = newStats;
                            _towerCooldown.Update(Stats.Speed);
                            game.UpgradeTower(action);           
                        }
                    }
                }
            }
        }        
    }
}
