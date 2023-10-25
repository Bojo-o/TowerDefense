using TowerDefenseServer.Monsters;

namespace TowerDefenseServer.Tiles.Towers
{
    public class IceTower : Tower
    {
        protected override bool AttackToMonster(Monster monster)
        {
            return monster.TowerAttack(this);
        }
    }
}
