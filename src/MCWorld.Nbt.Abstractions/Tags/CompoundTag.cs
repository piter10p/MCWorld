namespace MCWorld.Nbt.Abstractions.Tags
{
    public class CompoundTag : ITag
    {
        public CompoundTag(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
