using TowerDefenseServer.Tiles.Towers;

namespace TowerDefenseServer.Monsters
{
    /// <summary>
    /// Interface for all existed towers attacks.
    /// </summary>
    public interface ITowerAttacks
    {
        bool TowerAttack(AirTower tower);
        bool TowerAttack(AirTurretTower tower);
        bool TowerAttack(ArcherTower tower);
        bool TowerAttack(CanonTower tower);
        bool TowerAttack(ExplodeTower tower);
        bool TowerAttack(FireTower tower);
        bool TowerAttack(IceTower tower);
        bool TowerAttack(PoisonTower tower);
        bool TowerAttack(StormTower tower);
        bool TowerAttack(TurretTower tower);
        bool TowerAttack(WindTower tower);
    }
}
