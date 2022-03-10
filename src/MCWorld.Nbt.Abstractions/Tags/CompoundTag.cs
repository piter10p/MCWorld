using System.Collections.Generic;

namespace MCWorld.Nbt.Abstractions.Tags
{
    public class CompoundTag : ITag
    {
        private List<ITag> _tags;

        public CompoundTag(string name, List<ITag> tags)
        {
            Name = name ?? throw new System.ArgumentNullException(nameof(name));
            _tags = tags ?? throw new System.ArgumentNullException(nameof(tags));
        }

        public string Name { get; }

        public IEnumerable<ITag> Tags => _tags;
    }
}
