namespace MCWorld.Nbt.Abstractions.Tags
{
    public class ShortTag : ITag
    {
        public ShortTag(string name, short value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public short Value { get; }
    }
}
