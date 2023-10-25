using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Tiles.Towers
{
    /// <summary>
    /// Generic factory, which produces new towers.
    /// Represents concrate factories in Factory pattern.
    /// </summary>
    /// <typeparam name="TowerType">Concrate kind of tower</typeparam>
    public class TowerFactory<TowerType> : ITowerFactory where TowerType : Tower, new()
    {
        private TowerStats _towerStats;
        private readonly int _tileSize;
        public TowerFactory(TowerStats towerStats,int tileSize)
        {
            this._towerStats = towerStats;
            this._tileSize = tileSize;
        }
        public Tower CreateTower(PlayerID owner,Point gridLocation)
        {
            var constructedTower = new TowerType();
            constructedTower.SetTowerPropetries(this._towerStats,gridLocation,_tileSize);
            constructedTower.SetOwner(owner);
            return constructedTower;
        }
    }
}
