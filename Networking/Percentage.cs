namespace TowerDefenseNetworking
{
    /// <summary>
    /// Stores % value in range 0%-100%.
    /// </summary>
    public struct Percentage
    {
        public int Value { get; private set; }
        /// <summary>
        /// If the value is not in range, it simple modules that value.
        /// </summary>
        /// <param name="value">value which will be represented  in %</param>
        public Percentage(int value)
        {
            if (value == 100)
            {
                this.Value = 100;
            }
            else
            {
                this.Value = value % 100;
            }
        }
    }
}
