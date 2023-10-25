using TowerDefenseServer.Tiles.Towers;
using TowerDefenseNetworking;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Monsters
{
    public class Dragon : Monster
    {        
        public override MonsterRenderInfo GetMonsterRenderInfo()
        {
            var renderInfo = PrepareRenderInfo();
            renderInfo.MonsterType = MonsterTypes.Dragon;
            return renderInfo;
        }
        public override bool TowerAttack(AirTower tower)
        {
            DealDamage(ComputeFunc.Reduce(tower.Stats.Damage, new Percentage(20)));
            return true;
        }
        public override bool TowerAttack(AirTurretTower tower)
        {
            DealDamage(tower.Stats.Damage);
            return true;
        }
        public override bool TowerAttack(WindTower tower)
        {
            DealSlowness(new Percentage(tower.Stats.Damage));
            return true;
        }
        public override bool TowerAttack(StormTower tower)
        {
            DealDamage(ComputeFunc.Increase(tower.Stats.Damage, new Percentage(50)));
            return true;
        }
        public override bool TowerAttack(PoisonTower tower)
        {
            DealDamage(tower.Stats.Damage);
            return true;
        }
        public override bool TowerAttack(ExplodeTower tower)
        {
            DealDamage(ComputeFunc.Increase(tower.Stats.Damage, new Percentage(15)));
            return true;
        }
    }
}
