using TowerDefenseServer.Monsters;

namespace TowerDefenseServer.Tiles.Towers
{
    public class ArcherTower : Tower
    {
        static ArcherTower()
        {
            IsSingleAttacker = true;
        }
        protected override bool AttackToMonster(Monster monster)
        {
            return monster.TowerAttack(this);
        }
    }
}
