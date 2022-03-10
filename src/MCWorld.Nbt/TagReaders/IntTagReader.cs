using MCWorld.Nbt.TagData;
using System;
using System.IO;

namespace MCWorld.Nbt.TagReaders
{
    internal class IntTagReader : ITagReader
    {
        public ITagData ReadTag(Stream stream)
        {
            var dataBytes = new byte[4];
            stream.Read(dataBytes, 0, 4);
            dataBytes = EndianConverter.ConvertNumberIfLocalFormatIsLittleEndian(dataBytes);
            var value = BitConverter.ToInt32(dataBytes);
            return new IntTagData
            {
                Value = value
            };
        }
    }
}
