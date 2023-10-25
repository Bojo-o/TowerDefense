using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefenseServer.Tiles.Towers;
using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Monsters
{
    public class Bear : Monster
    {       
        public override MonsterRenderInfo GetMonsterRenderInfo()
        {
            var renderInfo = PrepareRenderInfo();
            renderInfo.MonsterType = MonsterTypes.Bear;
            return renderInfo;
        }
        public override bool TowerAttack(ArcherTower tower)
        {
            DealDamage(ComputeFunc.Reduce(tower.Stats.Damage,new Percentage(15)));
            return true;
        }
        public override bool TowerAttack(CanonTower tower)
        {
            DealDamage(ComputeFunc.Reduce(tower.Stats.Damage,new Percentage(5)));
            return true;
        }
        public override bool TowerAttack(TurretTower tower)
        {
            DealDamage(tower.Stats.Damage);
            return true;
        }
        public override bool TowerAttack(IceTower tower)
        {
            DealSlowness(new Percentage(tower.Stats.Damage));
            return true;
        }
        public override bool TowerAttack(FireTower tower)
        {
            DealDamage(tower.Stats.Damage);
            return true;
        }
        public override bool TowerAttack(PoisonTower tower)
        {
            DealDamage(tower.Stats.Damage);
            return true;
        }
        public override bool TowerAttack(ExplodeTower tower)
        {
            DealDamage(tower.Stats.Damage);
            return true;
        }
    }
}
