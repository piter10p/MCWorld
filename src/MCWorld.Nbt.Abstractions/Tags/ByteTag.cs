namespace MCWorld.Nbt.Abstractions.Tags
{
    public class ByteTag : ITag
    {
        public ByteTag(string name, byte value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public byte Value { get; }
    }
}
