namespace CHStore.Core.ValueObjects
{
    public class Size
    {
        public decimal Length { get; private set; }
        public decimal Width { get; private set; }
        public decimal Depth { get; private set; }

        public Size(
            decimal length,
            decimal width,
            decimal depth)
        {
            Length = length;
            Width = width;
            Depth = depth;
        }
    }
}
