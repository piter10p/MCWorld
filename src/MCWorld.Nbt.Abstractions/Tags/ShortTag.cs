namespace MCWorld.Nbt.Abstractions.Tags
{
    public class ShortTag : ITag
    {
        public ShortTag(string name, short value)
        {
            Name = name ?? throw new System.ArgumentNullException(nameof(name));
            Value = value;
        }

        public string Name { get; }
        public short Value { get; }
    }
}
