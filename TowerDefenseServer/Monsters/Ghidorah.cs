using TowerDefenseServer.Tiles.Towers;
using TowerDefenseNetworking;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Monsters
{
    public class Ghidorah : Monster
    {       
        public override MonsterRenderInfo GetMonsterRenderInfo()
        {
            var renderInfo = PrepareRenderInfo();
            renderInfo.MonsterType = MonsterTypes.Ghidorah;
            return renderInfo;
        }
        public override bool TowerAttack(AirTower tower)
        {
            DealDamage(ComputeFunc.Reduce(tower.Stats.Damage, new Percentage(30)));
            return true;
        }
        public override bool TowerAttack(AirTurretTower tower)
        {
            DealDamage(tower.Stats.Damage);
            return true;
        }
        public override bool TowerAttack(WindTower tower)
        {
            DealSlowness(new Percentage(ComputeFunc.Reduce(tower.Stats.Damage, new Percentage(5))));
            return true;
        }
        public override bool TowerAttack(ExplodeTower tower)
        {
            DealDamage(ComputeFunc.Increase(tower.Stats.Damage,new Percentage(20)));
            return true;
        }
    }
}
