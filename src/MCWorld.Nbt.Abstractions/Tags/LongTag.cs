namespace MCWorld.Nbt.Abstractions.Tags
{
    public class LongTag : ITag
    {
        public LongTag(string name, long value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public long Value { get; }
    }
}
