﻿using TowerDefenseServer.Tiles.Towers;
using TowerDefenseNetworking;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Monsters
{
    public class Golem : Monster
    {        
        public override MonsterRenderInfo GetMonsterRenderInfo()
        {
            var renderInfo = PrepareRenderInfo();
            renderInfo.MonsterType = MonsterTypes.Golem;
            return renderInfo;
        }
        public override bool TowerAttack(ArcherTower tower)
        {
            DealDamage(tower.Stats.Damage);
            return true;
        }
        public override bool TowerAttack(CanonTower tower)
        {
            DealDamage(ComputeFunc.Increase(tower.Stats.Damage, new Percentage(25)));
            return true;
        }
        public override bool TowerAttack(IceTower tower)
        {
            DealSlowness(new Percentage(tower.Stats.Damage));
            return true;
        }
        public override bool TowerAttack(PoisonTower tower)
        {
            DealDamage(ComputeFunc.Increase(tower.Stats.Damage, new Percentage(5)));
            return true;
        }
        public override bool TowerAttack(ExplodeTower tower)
        {
            DealDamage(ComputeFunc.Increase(tower.Stats.Damage, new Percentage(30)));
            return true;
        }
    }
}
