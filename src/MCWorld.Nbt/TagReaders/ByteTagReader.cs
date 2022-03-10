using MCWorld.Nbt.TagData;
using System;
using System.IO;

namespace MCWorld.Nbt.TagReaders
{
    internal class ByteTagReader : ITagReader
    {
        public ITagData ReadTag(Stream stream)
        {
            var value = Convert.ToByte(stream.ReadByte());
            return new ByteTagData
            {
                Value = value
            };
        }
    }
}
