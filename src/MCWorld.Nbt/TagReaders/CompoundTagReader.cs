using MCWorld.Nbt.Abstractions.Tags;
using System.IO;

namespace MCWorld.Nbt.TagReaders
{
    internal class CompoundTagReader : ITagReader
    {
        public ITag ReadTag(Stream stream)
        {
            var name = TagNameReader.ReadTagName(stream);
            return new CompoundTag(name);
        }
    }
}
