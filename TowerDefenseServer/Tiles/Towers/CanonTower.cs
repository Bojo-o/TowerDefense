using TowerDefenseServer.Monsters;

namespace TowerDefenseServer.Tiles.Towers
{
    public class CanonTower : Tower
    {
        static CanonTower()
        {
            IsSingleAttacker = true;
        }
        protected override bool AttackToMonster(Monster monster)
        {
            return monster.TowerAttack(this);
        }
    }
}
