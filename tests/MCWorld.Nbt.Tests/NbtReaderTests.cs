using MCWorld.Nbt.TagData;
using MCWorld.Nbt.Tests.Utilities;
using System.IO;
using Xunit;

namespace MCWorld.Nbt.Tests
{
    public class NbtReaderTests
    {
        [Fact]
        public void ReadDocumentData_ShouldReturnExpected()
        {
            //Arrange
            var testData = new TestDataBuilder()
                .AddType(NbtTagType.Compound)
                .AddTagName(string.Empty)
                    .AddType(NbtTagType.Byte)
                    .AddTagName("byte")
                    .AddByte(5)
                    .AddType(NbtTagType.Short)
                    .AddTagName("short")
                    .AddShort(123)
                    .AddType(NbtTagType.Int)
                    .AddTagName("int")
                    .AddInt(234234)
                    .AddType(NbtTagType.Long)
                    .AddTagName("long")
                    .AddLong(2345345345)
                    .AddType(NbtTagType.Compound)
                    .AddTagName("compound 1")
                        .AddType(NbtTagType.Int)
                        .AddTagName("int1")
                        .AddInt(123)
                        .AddType(NbtTagType.List)
                        .AddTagName("list")
                        .AddType(NbtTagType.Compound)
                        .AddInt(2)
                            .AddTagName("compound 1.1")
                                .AddType(NbtTagType.Short)
                                .AddTagName("short1")
                                .AddShort(5)
                                .AddType(NbtTagType.End)
                            .AddTagName("compound 1.2")
                            .AddType(NbtTagType.End)
                        .AddType(NbtTagType.End)
                .AddType(NbtTagType.End)
                .Bytes;

            var stream = new MemoryStream(testData);
            var sut = new NbtReader(stream);

            //Act
            var rootTagData = (CompoundTagData)sut.ReadDocumentData();
        }
    }
}
