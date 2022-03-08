namespace MCWorld.Nbt.Abstractions.Tags
{
    public class IntTag : ITag
    {
        public IntTag(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public int Value { get; }
    }
}
