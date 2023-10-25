using System.Collections.Generic;
using TowerDefenseServer.Monsters;

namespace TowerDefenseServer
{
    /// <summary>
    /// Spawns monsters.
    /// </summary>
    /// <remarks>
    /// When player sends more monsters at same time, it add monsters to monster spawn queue,
    /// and every times cooldown expire it spawns one monster.
    /// </remarks>
    public class MonsterSpawner
    {
        private readonly Cooldown _spawnCooldown;
        /// <summary>
        /// List of player monsters, when spawner spawns a new monster, it adds monster to the list.
        /// </summary>
        private readonly List<Monster> _spawnedMonsters;
        /// <summary>
        /// Queue where monsters waiting to be spawned.
        /// </summary>
        private readonly Queue<Monster> _spawningQueue;
        /// <summary>
        /// Set properties of spawner.
        /// </summary>
        /// <param name="playerMonstersList">Reference on list of player spawned monsters</param>
        /// <param name="cooldown">cooldown, which process expiration of time</param>
        public MonsterSpawner(List<Monster> playerMonstersList,Cooldown cooldown)
        {
            _spawnedMonsters = playerMonstersList;
            _spawningQueue = new Queue<Monster>();
            _spawnCooldown = cooldown;
        }
        /// <summary>
        /// Add monster to the players list, that means the monster will be spawned.
        /// </summary>
        /// <param name="monster">the monster, which will be spawned</param>
        public void AddMonster(Monster monster)
        {
            _spawningQueue.Enqueue(monster);
        }
        /// <summary>
        /// If there is some monster waiting to be spawns and time already has passed, it spawns a new monster.
        /// </summary>
        public void TrySpawnMonster()
        {
            if(_spawningQueue.Count > 0 && _spawnCooldown.IsReady)
            {
                _spawnedMonsters.Add(_spawningQueue.Dequeue());
                _spawnCooldown.Start();
            }
        }
    }
}
