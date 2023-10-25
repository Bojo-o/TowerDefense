using System;
using TowerDefenseNetworking;

namespace TowerDefenseServer
{
    /// <summary>
    /// Funcs, which calculates. It helps game entities compute something.
    /// </summary>
    public static class ComputeFunc
    {
        /// <summary>
        /// Computes distance between two points in space.
        /// </summary>
        /// <returns>distance</returns>
        public static int GetDistance(Point a,Point b)
        {
            var xDiff = Math.Abs(a.X - b.X);
            var yDiff = Math.Abs(a.Y - b.Y);
            return (int)Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }
        /// <summary>
        /// Computes what is the percentage value of the given value.
        /// </summary>
        /// <param name="value">value, representing 100% of value</param>
        /// <param name="percentage">given %</param>
        /// <returns>a new value</returns>
        private static int GetPercantageValue(int value, Percentage percentage)
        {
            return (int)((double)value * ((double)percentage.Value / 100.0));
        }
        /// <summary>
        /// Reduce the value by given percentage.
        /// </summary>
        /// <param name="value">value, which will be reduced</param>
        /// <param name="percentage">value of %,represents how much will be value reduced </param>
        /// <returns>reduced value</returns>
        public static int Reduce(int value,Percentage percentage)
        {
            return value - GetPercantageValue(value, percentage);
        }
        /// <summary>
        /// Increase the value by given percentage.
        /// </summary>
        /// <param name="value">value, which will be increased</param>
        /// <param name="percentage">value of %,represents how much will be value increased</param>
        /// <returns>increased value</returns>
        public static int Increase(int value, Percentage percentage)
        {
            return value + GetPercantageValue(value, percentage);
        }
    }
}
