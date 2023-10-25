using System.Drawing;
using TowerDefenseNetworking.TypeEnums;
using TowerDefenseNetworking;

namespace TowerDefenseClient
{
    /// <summary>
    /// Game entity, represents certain concrate game tile in the game map.
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// Size of tile.
        /// </summary>
        private static readonly int TileSize = 64;
        /// <summary>
        /// Location, where tile is located.
        /// </summary>
        private TowerDefenseNetworking.Point _gridLocation;
        /// <summary>
        /// Image of tile, which is rendered on screen.
        /// </summary>
        private readonly Bitmap _spriteImage;
        /// <summary>
        /// For certain tiles we needs to know who is owner, who has right to use that tile.
        /// </summary>
        private readonly PlayerID _owner;
        /// <summary>
        /// When player clicks at tile, it should invoke right UI menu.
        /// </summary>
        private readonly UITypes _actionUIType;
        /// <summary>
        /// Assing tile property.
        /// </summary>
        /// <param name="gridLocation">location of tile</param>
        /// <param name="spriteImage">image of tile, which is rendered on the screen</param>
        /// <param name="tileOwner">player owner of tile</param>
        /// <param name="actionUI">type of UI menu, which will be opened after player clicked at this tile</param>
        public Tile(TowerDefenseNetworking.Point gridLocation, Bitmap spriteImage,PlayerID tileOwner,UITypes actionUI)
        {
            this._gridLocation = gridLocation;
            this._spriteImage = spriteImage;
            this._owner = tileOwner;
            this._actionUIType = actionUI;
        }
        /// <summary>
        /// Draw tile image on the screen.
        /// </summary>
        /// <param name="g">graphics, into which we draw the picture</param>
        public void Draw(Graphics g)
        {
            g.DrawImage(_spriteImage, new Rectangle(_gridLocation.X * TileSize, _gridLocation.Y * TileSize, TileSize, TileSize));
        }
        /// <summary>
        /// If player clicked on tile and also own it, it invoke right UI menu.
        /// </summary>
        /// <param name="game">game, to be able notify over it win form, which then opens right UI menu</param>
        public void Action(Game game)
        {
            if (_owner == game.PlayerID)
            {
                game.OpenMenu(_actionUIType);
            }
        }
    }
}
