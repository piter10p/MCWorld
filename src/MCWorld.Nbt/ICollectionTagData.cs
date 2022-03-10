using System.Collections.Generic;

namespace MCWorld.Nbt
{
    internal interface ICollectionTagData : ITagData
    {
        public List<ITagData> Tags { get; set; }
    }
}
