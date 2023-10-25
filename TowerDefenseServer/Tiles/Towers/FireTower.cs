using TowerDefenseServer.Monsters;

namespace TowerDefenseServer.Tiles.Towers
{
    public class FireTower : Tower
    {
        protected override bool AttackToMonster(Monster monster)
        {
            return monster.TowerAttack(this);
        }
    }
}
