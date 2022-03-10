using MCWorld.Nbt.TagReaders;
using System;

namespace MCWorld.Nbt
{
    internal static class TagReaderResolver
    {
        private static readonly ByteTagReader ByteTagReader = new ByteTagReader();
        private static readonly ShortTagReader ShortTagReader = new ShortTagReader();
        private static readonly IntTagReader IntTagReader = new IntTagReader();
        private static readonly LongTagReader LongTagReader = new LongTagReader();

        private static readonly ListTagReader ListTagReader = new ListTagReader();

        public static ITagReader GetTagReader(NbtTagType tagType)
        {
            return tagType switch
            {
                NbtTagType.Byte => ByteTagReader,
                NbtTagType.Short => ShortTagReader,
                NbtTagType.Int => IntTagReader,
                NbtTagType.Long => LongTagReader,
                NbtTagType.Float => throw new System.NotImplementedException(),
                NbtTagType.Double => throw new System.NotImplementedException(),
                NbtTagType.ByteArray => throw new System.NotImplementedException(),
                NbtTagType.String => throw new System.NotImplementedException(),
                NbtTagType.List => ListTagReader,
                NbtTagType.IntArray => throw new System.NotImplementedException(),
                NbtTagType.LongArray => throw new System.NotImplementedException(),
                _ => throw new NotSupportedException()
            };
        }
    }
}
