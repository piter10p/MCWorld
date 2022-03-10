using System.Collections.Generic;

namespace MCWorld.Nbt.TagData
{
    internal class ListTagData : ICollectionTagData
    {
        public string Name { get; set; }
        public NbtTagType PayloadType { get; set; }
        public int PayloadSize { get; set; }
        public List<ITagData> Tags { get; set; }
    }
}
