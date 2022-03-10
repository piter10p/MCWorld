namespace MCWorld.Nbt.Abstractions.Tags
{
    public class LongTag : ITag
    {
        public LongTag(string name, long value)
        {
            Name = name ?? throw new System.ArgumentNullException(nameof(name));
            Value = value;
        }

        public string Name { get; }
        public long Value { get; }
    }
}
