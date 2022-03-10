using System;
using System.IO;
using System.Text;

namespace MCWorld.Nbt
{
    internal static class TagNameReader
    {
        public static string ReadTagName(Stream stream)
        {
            const int lenghtBytesCount = 2;
            var lengthBytes = new byte[lenghtBytesCount];
            stream.Read(lengthBytes, 0, lenghtBytesCount);
            lengthBytes = EndianConverter.ConvertNumberIfLocalFormatIsLittleEndian(lengthBytes);
            var nameLength = BitConverter.ToUInt16(lengthBytes, 0);

            var nameBytes = new byte[nameLength];
            stream.Read(nameBytes, 0, nameLength);
            return Encoding.UTF8.GetString(nameBytes);
        }
    }
}
