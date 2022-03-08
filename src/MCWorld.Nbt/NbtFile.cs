using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace MCWorld.Nbt
{
    public static class NbtFile
    {
        public static async Task<NbtReader> Open(string filePath)
        {
            using var compressedFileStream = File.Open(filePath, FileMode.Open);
            using var zipStream = new GZipStream(compressedFileStream, CompressionMode.Decompress);

            var decompressedMemoryStream = new MemoryStream();
            await zipStream.CopyToAsync(decompressedMemoryStream);

            decompressedMemoryStream.Seek(0, SeekOrigin.Begin);
            return new NbtReader(decompressedMemoryStream);
        }
    }
}
