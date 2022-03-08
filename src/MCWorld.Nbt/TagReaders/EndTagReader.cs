using MCWorld.Nbt.Abstractions.Tags;
using System.IO;

namespace MCWorld.Nbt.TagReaders
{
    internal class EndTagReader : ITagReader
    {
        public ITag ReadTag(Stream stream)
        {
            return new EndTag();
        }
    }
}
