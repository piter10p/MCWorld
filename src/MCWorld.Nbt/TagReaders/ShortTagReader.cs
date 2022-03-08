using MCWorld.Nbt.Abstractions.Tags;
using System;
using System.IO;

namespace MCWorld.Nbt.TagReaders
{
    internal class ShortTagReader : ITagReader
    {
        public ITag ReadTag(Stream stream)
        {
            var name = TagNameReader.ReadTagName(stream);
            var dataBytes = new byte[2];
            stream.Read(dataBytes, 0, 2);
            dataBytes = EndianConverter.ConvertNumberIfLocalFormatIsLittleEndian(dataBytes);
            var value = BitConverter.ToInt16(dataBytes);
            return new ShortTag(name, value);
        }
    }
}
