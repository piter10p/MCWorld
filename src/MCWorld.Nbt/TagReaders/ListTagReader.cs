using MCWorld.Nbt.TagData;
using System;
using System.IO;

namespace MCWorld.Nbt.TagReaders
{
    internal class ListTagReader : ITagReader
    {
        public ITagData ReadTag(Stream stream)
        {
            var type = (NbtTagType)stream.ReadByte();

            var sizeDataBytes = new byte[4];
            stream.Read(sizeDataBytes, 0, 4);
            sizeDataBytes = EndianConverter.ConvertNumberIfLocalFormatIsLittleEndian(sizeDataBytes);
            var payloadSize = BitConverter.ToInt32(sizeDataBytes);

            return new ListTagData
            {
                PayloadType = type,
                PayloadSize = payloadSize
            };
        }
    }
}
