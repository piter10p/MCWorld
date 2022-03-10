namespace MCWorld.Nbt.Abstractions.Tags
{
    public class IntTag : ITag
    {
        public IntTag(string name, int value)
        {
            Name = name ?? throw new System.ArgumentNullException(nameof(name));
            Value = value;
        }

        public string Name { get; }
        public int Value { get; }
    }
}
