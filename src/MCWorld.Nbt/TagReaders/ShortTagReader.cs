using MCWorld.Nbt.TagData;
using System;
using System.IO;

namespace MCWorld.Nbt.TagReaders
{
    internal class ShortTagReader : ITagReader
    {
        public ITagData ReadTag(Stream stream)
        {
            var dataBytes = new byte[2];
            stream.Read(dataBytes, 0, 2);
            dataBytes = EndianConverter.ConvertNumberIfLocalFormatIsLittleEndian(dataBytes);
            var value = BitConverter.ToInt16(dataBytes);
            return new ShortTagData
            {
                Value = value
            };
        }
    }
}
