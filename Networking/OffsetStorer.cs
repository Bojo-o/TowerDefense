namespace TowerDefenseNetworking
{
    /// <summary>
    /// Struct, which stores offset value, so when we writes to the data, which will be send over the network,
    /// we not must remember offset.
    /// </summary>
    public class OffsetStorer
    {
        public int Offset { get; private set; }
        public OffsetStorer(int startingIndex)
        {
            this.Offset = startingIndex;
        }
        /// <summary>
        /// Update offset, increase value of the offset.
        /// </summary>
        /// <param name="value">value of how much the offset will be increased</param>
        public void Increase(int value)
        {
            this.Offset += value;
        }
    }
}
