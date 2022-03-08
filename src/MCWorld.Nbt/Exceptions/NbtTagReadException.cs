using System;
using System.Runtime.Serialization;

namespace MCWorld.Nbt.Exceptions
{
    public class NbtTagReadException : Exception
    {
        public long TagStreamPosition { get; }

        public NbtTagReadException(string message, long tagStreamPosition) : base(message)
        {
            TagStreamPosition = tagStreamPosition;
        }

        public NbtTagReadException()
        {
        }

        public NbtTagReadException(string message) : base(message)
        {
        }

        public NbtTagReadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NbtTagReadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
