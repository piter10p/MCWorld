using System.Collections.Generic;

namespace MCWorld.Nbt.TagData
{
    internal class CompoundTagData : ICollectionTagData
    {
        public string Name { get; set; }
        public List<ITagData> Tags { get; set; } = new List<ITagData>();
    }
}
