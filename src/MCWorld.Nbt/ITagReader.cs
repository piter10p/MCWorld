using System.IO;

namespace MCWorld.Nbt
{
    internal interface ITagReader
    {
        public ITagData ReadTag(Stream stream);
    }
}
