using MCWorld.Nbt.TagData;
using System;
using System.IO;

namespace MCWorld.Nbt.TagReaders
{
    internal class LongTagReader : ITagReader
    {
        public ITagData ReadTag(Stream stream)
        {
            var dataBytes = new byte[8];
            stream.Read(dataBytes, 0, 8);
            dataBytes = EndianConverter.ConvertNumberIfLocalFormatIsLittleEndian(dataBytes);
            var value = BitConverter.ToInt64(dataBytes);
            return new LongTagData
            {
                Value = value
            };
        }
    }
}
