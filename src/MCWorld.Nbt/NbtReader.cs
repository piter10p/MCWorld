using MCWorld.Nbt.Abstractions;
using MCWorld.Nbt.Abstractions.Tags;
using MCWorld.Nbt.Exceptions;
using MCWorld.Nbt.TagReaders;
using System;
using System.IO;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("MCWorld.Nbt.Tests")]
namespace MCWorld.Nbt
{
    public class NbtReader : INbtReader, IDisposable
    {
        private MemoryStream _stream;

        public NbtReader(MemoryStream stream)
        {
            _stream = stream ?? throw new System.ArgumentNullException(nameof(stream));
        }

        public void Dispose()
        {
            ((IDisposable)_stream).Dispose();
        }

        public ITag GetNextTag()
        {
            return ReadTag();
        }

        public byte[] GetAllBytes()
        {
            var bytes = _stream.ToArray();
            _stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        private ITag ReadTag()
        {
            var tagPosition = _stream.Position;
            var tagType = GetTagType(tagPosition);
            var tagReader = NbtTagReaderResolver.GetTagReader(tagType);
            return tagReader.ReadTag(_stream);
        }

        private NbtTagType GetTagType(long tagPosition)
        {
            var typeByte = _stream.ReadByte();

            if (typeByte < 0)
                throw new EndOfStreamException();

            if (typeByte > 12)
                throw new NbtTagReadException($"Type byte value invalid: {typeByte}", tagPosition);

            return (NbtTagType)typeByte;
        }
    }
}
