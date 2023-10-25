using System.Drawing;
using TowerDefenseNetworking;

namespace TowerDefenseClient
{
    /// <summary>
    /// Game enity, which represents circle around tower of the tower range radius.
    /// </summary>
    public class TowerRangeCircle
    {
        private const int PenWidth = 2;
        private readonly Pen _pen;
        private Rectangle _rangeRect;
        /// <summary>
        /// Assing and construct range circle.
        /// </summary>
        /// <param name="range">range value of tower</param>
        /// <param name="circleColor">color of circle</param>
        /// <param name="circleMiddlePoint">middle point of cicle, which means middle point of the certain tower tile</param>
        public TowerRangeCircle(int range,Color circleColor, TowerDefenseNetworking.Point circleMiddlePoint)
        {
            _pen = new Pen(circleColor,PenWidth);
            var radius = range / 2;
            _rangeRect = new Rectangle(circleMiddlePoint.X - radius, circleMiddlePoint.Y - radius, range, range );
        }
        /// <summary>
        /// Assing a new value, so circle will be updated.
        /// </summary>
        /// <remarks>
        /// If tower is upgraded, then their range is increased so range circle radius must be upgraded.
        /// </remarks>
        /// <param name="range">a new tower range value</param>
        public void UpdateRangeValue(int range)
        {
            var oldRadius = _rangeRect.Width / 2 ;
            _rangeRect.X = _rangeRect.X + oldRadius - range/2;
            _rangeRect.Y = _rangeRect.Y + oldRadius - range/2;
            _rangeRect.Width = range;
            _rangeRect.Height = range;
        }
        /// <summary>
        /// Draw tower range circle on the screen.
        /// </summary>
        /// <param name="g">game graphics, on which a circle will be rendered</param>
        public void Draw(Graphics g)
        {
            g.DrawEllipse(_pen, _rangeRect);
        }
    }
}
