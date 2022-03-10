using System;
using System.Collections.Generic;
using System.Text;

namespace MCWorld.Nbt.Tests.Utilities
{
    internal class TestDataBuilder
    {
        private List<byte> _bytes = new List<byte>();

        public byte[] Bytes => _bytes.ToArray();

        public TestDataBuilder AddType(NbtTagType tagType)
        {
            _bytes.Add((byte)tagType);
            return this;
        }

        public TestDataBuilder AddByte(byte b)
        {
            _bytes.Add(b);
            return this;
        }

        public TestDataBuilder AddShort(short s)
        {
            var value = BitConverter.GetBytes(s);
            value = EndianConverter.ConvertNumberIfLocalFormatIsLittleEndian(value);
            _bytes.AddRange(value);
            return this;
        }

        public TestDataBuilder AddInt(int i)
        {
            var value = BitConverter.GetBytes(i);
            value = EndianConverter.ConvertNumberIfLocalFormatIsLittleEndian(value);
            _bytes.AddRange(value);
            return this;
        }

        public TestDataBuilder AddLong(long l)
        {
            var value = BitConverter.GetBytes(l);
            value = EndianConverter.ConvertNumberIfLocalFormatIsLittleEndian(value);
            _bytes.AddRange(value);
            return this;
        }

        public TestDataBuilder AddString(string str)
        {
            var value = Encoding.UTF8.GetBytes(str);
            _bytes.AddRange(value);
            return this;
        }

        public TestDataBuilder AddTagName(string str)
        {
            var nameLength = Convert.ToUInt16(str.Length);
            var nameLengthBytes = BitConverter.GetBytes(nameLength);
            nameLengthBytes = EndianConverter.ConvertNumberIfLocalFormatIsLittleEndian(nameLengthBytes);
            _bytes.AddRange(nameLengthBytes);

            var nameBytes = Encoding.UTF8.GetBytes(str);
            _bytes.AddRange(nameBytes);
            return this;
        }
    }
}
