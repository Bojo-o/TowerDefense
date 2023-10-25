using TowerDefenseServer.Tiles.Towers;
using TowerDefenseNetworking;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Monsters
{
    public class Devil : Monster
    {       
        public override MonsterRenderInfo GetMonsterRenderInfo()
        {
            var renderInfo = PrepareRenderInfo();
            renderInfo.MonsterType = MonsterTypes.Devil;
            return renderInfo;
        }
        public override bool TowerAttack(ArcherTower tower)
        {
            DealDamage(tower.Stats.Damage);
            return true;
        }
        public override bool TowerAttack(CanonTower tower)
        {
            DealDamage(ComputeFunc.Reduce(tower.Stats.Damage, new Percentage(20)));
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
        public override bool TowerAttack(PoisonTower tower)
        {
            DealDamage(ComputeFunc.Increase(tower.Stats.Damage, new Percentage(10)));
            return true;
        }
        public override bool TowerAttack(ExplodeTower tower)
        {
            DealDamage(ComputeFunc.Reduce(tower.Stats.Damage,new Percentage(10)));
            return true;
        }
    }
}
