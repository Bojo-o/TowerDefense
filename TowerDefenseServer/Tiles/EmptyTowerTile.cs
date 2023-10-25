using TowerDefenseNetworking;
using TowerDefenseNetworking.Stats;
using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseServer.Tiles
{
    /// <summary>
    /// Represent tile, which is emty and player is able to built here towers.
    /// </summary>
    public class EmptyTowerTile : Tile
    {
        public PlayerID TileOwner { get; private set; }
        /// <summary>
        /// Set owner of tile, the server knows who player is able to built tower here.
        /// </summary>
        /// <param name="owner">player ID, who owns this tile</param>
        public void SetOwner(PlayerID owner)
        {
            this.TileOwner = owner;
        }
        /// <summary>
        /// Process action of building tower.
        /// </summary>
        /// <remarks>
        /// It checks if player can build here, has enough golds for this.
        /// </remarks>
        /// <param name="game">game on the server side</param>
        /// <param name="action">contains information about tower, which player would like to built</param>
        public override void Action(Game game, TowerAction action)
        {
            if (action.TowerActionType == TowerActionTypes.Build)
            {
                if (TileOwner == action.PlayerID)
                {
                    var player = game.GetPlayer(action.PlayerID);
                    Game.TowerStatsDict.TryGetValue(action.TowerType, out TowerStats towerStats);
                    if (player.UseGolds(towerStats.BuildPrice))
                    {
                        game.BuildTower(action);
                    }
                }
            }
        }
    }
}
