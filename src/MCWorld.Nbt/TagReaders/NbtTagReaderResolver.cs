namespace MCWorld.Nbt.TagReaders
{
    internal static class NbtTagReaderResolver
    {
        private static readonly EndTagReader EndTagReader = new EndTagReader();
        private static readonly ByteTagReader ByteTagReader = new ByteTagReader();
        private static readonly ShortTagReader ShortTagReader = new ShortTagReader();
        private static readonly IntTagReader IntTagReader = new IntTagReader();
        private static readonly LongTagReader LongTagReader = new LongTagReader();
        private static readonly CompoundTagReader CompoundTagReader = new CompoundTagReader();

        public static ITagReader GetTagReader(NbtTagType tagType)
        {
            return tagType switch
            {
                NbtTagType.End => EndTagReader,
                NbtTagType.Byte => ByteTagReader,
                NbtTagType.Short => ShortTagReader,
                NbtTagType.Int => IntTagReader,
                NbtTagType.Long => LongTagReader,
                NbtTagType.Float => throw new System.NotImplementedException(),
                NbtTagType.Double => throw new System.NotImplementedException(),
                NbtTagType.ByteArray => throw new System.NotImplementedException(),
                NbtTagType.String => throw new System.NotImplementedException(),
                NbtTagType.List => throw new System.NotImplementedException(),
                NbtTagType.Compound => CompoundTagReader,
                NbtTagType.IntArray => throw new System.NotImplementedException(),
                NbtTagType.LongArray => throw new System.NotImplementedException(),
                _ => throw new System.NotImplementedException()
            };
        }
    }
}
