using MCWorld.Nbt.Abstractions.Tags;
using System.IO;

namespace MCWorld.Nbt.TagReaders
{
    internal interface ITagReader
    {
        public ITag ReadTag(Stream stream);
    }
}
