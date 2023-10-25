using TowerDefenseServer.Tiles.Towers;
using TowerDefenseNetworking;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Monsters
{
    public class Pterodactyl : Monster
    {        
        public override MonsterRenderInfo GetMonsterRenderInfo()
        {
            var renderInfo = PrepareRenderInfo();
            renderInfo.MonsterType = MonsterTypes.Pterodactyl;
            return renderInfo;
        }
        public override bool TowerAttack(AirTower tower)
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
