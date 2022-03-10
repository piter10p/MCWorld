using System;

namespace MCWorld.Nbt
{
    internal static class EndianConverter
    {
        public static byte[] ConvertNumberIfLocalFormatIsLittleEndian(byte[] number)
        {
            if (BitConverter.IsLittleEndian)
                return ReverseArray(number);

            return number;
        }

        private static byte[] ReverseArray(byte[] array)
        {
            var result = new byte[array.Length];

            for (var i = 0; i < array.Length; i++)
            {
                result[array.Length - 1 - i] = array[i];
            }

            return result;
        }
    }
}
