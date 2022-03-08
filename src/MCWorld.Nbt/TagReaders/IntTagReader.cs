using MCWorld.Nbt.Abstractions.Tags;
using System;
using System.IO;

namespace MCWorld.Nbt.TagReaders
{
    internal class IntTagReader : ITagReader
    {
        public ITag ReadTag(Stream stream)
        {
            var name = TagNameReader.ReadTagName(stream);
            var dataBytes = new byte[4];
            stream.Read(dataBytes, 0, 4);
            dataBytes = EndianConverter.ConvertNumberIfLocalFormatIsLittleEndian(dataBytes);
            var value = BitConverter.ToInt32(dataBytes);
            return new IntTag(name, value);
        }
    }
}
