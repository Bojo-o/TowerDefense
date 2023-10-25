using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Monsters
{
    /// <summary>
    /// Generic factory for producing new monsters.
    /// This represents concrates factories in Factory pattern.
    /// </summary>
    /// <typeparam name="MonsterType">represent concrate kind of monster, which will factory produced</typeparam>
    public class MonsterFactory<MonsterType> : IMonsterFactory  where MonsterType : Monster , new()
    {
        private readonly int _tileSize;
        private MonsterStats _monsterStats;

        public MonsterFactory(MonsterStats stats, int tileSize)
        {
            this._monsterStats = stats;
            this._tileSize = tileSize;
        }
        public Monster CreateMonster(GameMap gameMap, Point gridLocation)
        {
            var constructedMonster = new MonsterType();
            constructedMonster.SetMonsterPropetries(gameMap, _monsterStats, gridLocation, _tileSize);
            return constructedMonster;
        }
    }
}
