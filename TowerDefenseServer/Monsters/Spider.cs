using TowerDefenseServer.Tiles.Towers;
using TowerDefenseNetworking;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Monsters
{
    public class Spider : Monster
    {        
        public override MonsterRenderInfo GetMonsterRenderInfo()
        {
            var renderInfo = PrepareRenderInfo();
            renderInfo.MonsterType = MonsterTypes.Spider;
            return renderInfo;
        }
        public override bool TowerAttack(ArcherTower tower)
        {
            DealDamage(tower.Stats.Damage);
            return true;
        }
        public override bool TowerAttack(CanonTower tower)
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
