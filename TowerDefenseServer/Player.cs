using System.Collections.Generic;
using TowerDefenseServer.Monsters;
using TowerDefenseServer.Tiles.Towers;
using System.Diagnostics;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer
{  
    /// <summary>
    /// Represents player entity in the game. Stores all information about player such as HP , golds ,
    /// towers which player owns and monsters.
    /// </summary>
    public class Player
    {
        public int HP { get; private set; }
        public int Gold { get; private set; }
        public PlayerID PlayerID { get; private set; }
        public MonsterSpawner MonsterSpawner { get; private set; }
        public List<Tower> PlayerTowersList { get; private set; } = new List<Tower>();
        public List<Monster> PlayerMonstersList { get; private set; } = new List<Monster>();
        public List<Monster> PlayerDeadMonstersList { get; private set; } = new List<Monster>();
        /// <summary>
        /// Set starting value of player properties.
        /// </summary>
        /// <param name="hp">players starting HP</param>
        /// <param name="gold">players starting golds</param>
        /// <param name="playerID">players ID</param>
        public Player(int hp,int gold, PlayerID playerID)
        {
            this.HP = hp;
            this.Gold = gold;
            this.PlayerID = playerID;
        }
        /// <summary>
        /// Create a new Monster spawner, which spawns monsters.
        /// </summary>
        /// <param name="clock"></param>
        /// <param name="lenghtOfSpawningInMs">time in milliseconds, how much tiem must passed to spawns a new monster</param>
        public void InitMonsterSpawner(Stopwatch clock,int lenghtOfSpawningInMs)
        {
            MonsterSpawner = new MonsterSpawner(PlayerMonstersList, new Cooldown(clock, lenghtOfSpawningInMs));
        }
        /// <summary>
        /// Takes player HP by given damage.
        /// </summary>
        /// <param name="value">damage value</param>
        public void TakesDamage(int value)
        {
            if (HP < value)
            {
                HP = 0;
                return;
            }
            HP -= value;
        }
        /// <summary>
        /// Indicates if player is still alive.
        /// </summary>
        /// <returns>true if player has still HP</returns>
        public bool IsAlive()
        {
            return HP > 0;
        }
        /// <summary>
        /// Takes players golds, besauce player done some action, that costs golds.
        /// </summary>
        /// <param name="value">how much golds player must spends</param>
        /// <returns>true, if player has enough golds</returns>
        public bool UseGolds(int value)
        {
            if (Gold >= value)
            {
                Gold -= value;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Player obrain golds.
        /// </summary>
        /// <param name="value">how much golds player gets</param>
        public void GetGolds(int value)
        {
            Gold += value;
        }
        /// <summary>
        /// Add a new tower, which player owns to his list of towers.
        /// </summary>
        /// <param name="tower">a new tower</param>
        public void RegisterTower(Tower tower)
        {
            PlayerTowersList.Add(tower);
        }
        /// <summary>
        /// Remove the players tower, that means tower was sold by player.
        /// </summary>
        /// <param name="tower">tower, which will be destroyed</param>
        public void RemoveTower(Tower tower)
        {
            PlayerTowersList.Remove(tower);
        }     
        /// <summary>
        /// The monster is not alive, so it must be removed.
        /// </summary>
        /// <param name="monster">the monster, which is dead</param>
        public void KillMonster(Monster monster)
        {
            PlayerDeadMonstersList.Add(monster);
        }
        /// <summary>
        /// All monsters, which are not alive, it removes them.
        /// </summary>
        public void RemoveDeadMonsters()
        {
            foreach (var deadMonster in PlayerDeadMonstersList)
            {
                PlayerMonstersList.Remove(deadMonster);
            }
            PlayerDeadMonstersList.Clear();
        }
    }
}
