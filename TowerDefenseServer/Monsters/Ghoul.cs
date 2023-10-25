using TowerDefenseServer.Tiles.Towers;
using TowerDefenseNetworking;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Monsters
{
    public class Ghoul : Monster
    { 
        public override MonsterRenderInfo GetMonsterRenderInfo()
        {
            var renderInfo = PrepareRenderInfo();
            renderInfo.MonsterType = MonsterTypes.Ghoul;
            return renderInfo;
        }
        public override bool TowerAttack(ArcherTower tower)
        {
            DealDamage(ComputeFunc.Increase(tower.Stats.Damage, new Percentage(20)));
            return true;
        }
        public override bool TowerAttack(CanonTower tower)
        {
            DealDamage(tower.Stats.Damage);
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
            DealDamage(ComputeFunc.Increase(tower.Stats.Damage, new Percentage(15)));
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
