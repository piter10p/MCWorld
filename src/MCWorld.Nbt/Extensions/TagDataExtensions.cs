using MCWorld.Nbt.TagData;

namespace MCWorld.Nbt.Extensions
{
    internal static class TagDataExtensions
    {
        public static bool IsList(this ITagData tagData)
            => tagData is ListTagData;
    }
}
