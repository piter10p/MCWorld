using MCWorld.Nbt.Abstractions.Tags;
using System;
using System.IO;

namespace MCWorld.Nbt.TagReaders
{
    internal class ByteTagReader : ITagReader
    {
        public ITag ReadTag(Stream stream)
        {
            var name = TagNameReader.ReadTagName(stream);
            var value = Convert.ToByte(stream.ReadByte());
            return new ByteTag(name, value);
        }
    }
}
