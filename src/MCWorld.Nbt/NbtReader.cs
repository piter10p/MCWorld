using MCWorld.Nbt.Abstractions;
using MCWorld.Nbt.Abstractions.Tags;
using MCWorld.Nbt.Exceptions;
using MCWorld.Nbt.Extensions;
using MCWorld.Nbt.TagData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("MCWorld.Nbt.Tests")]
namespace MCWorld.Nbt
{
    public class NbtReader : INbtReader, IDisposable
    {
        private MemoryStream _stream;

        private Stack<ICollectionTagData> _parents;
        private ICollectionTagData _parent;
        private bool _isParentList;
        private ListTagData _listParent;

        public NbtReader(MemoryStream stream)
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        public void Dispose()
        {
            ((IDisposable)_stream).Dispose();
        }

        public CompoundTag ReadDocument()
        {
            var rootTagData = ReadDocumentData();

            return null;
        }

        public byte[] GetAllBytes()
        {
            var bytes = _stream.ToArray();
            _stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        public object ReadDocumentData()
        {
            _stream.Seek(0, SeekOrigin.Begin);

            var rootTag = ReadRootTag();

            _parents = new Stack<ICollectionTagData>();
            _parent = rootTag;
            _isParentList = false;
            _listParent = null;

            while (true)
            {
                var tagStreamPosition = _stream.Position;

                var tagType = _isParentList
                    ? _listParent.PayloadType
                    : GetTagType(tagStreamPosition); //only tags inside compound contains type

                if (tagType == NbtTagType.End) //end of compound
                {
                    if (_parent == rootTag) //end of root compound
                        break;

                    PopParent(); //when not root compound ends we get it's parent
                }
                else
                {
                    var name = _isParentList
                        ? null
                        : TagNameReader.ReadTagName(_stream); //only tags inside compound contains name

                    if (tagType == NbtTagType.Compound)
                    {
                        var tagData = new CompoundTagData
                        {
                            Name = name,
                        };

                        _parent.Tags.Add(tagData);
                        PushParent(tagData);
                    }
                    else if (tagType == NbtTagType.List)
                    {
                        var tagReader = TagReaderResolver.GetTagReader(tagType);
                        var tagData = (ListTagData)tagReader.ReadTag(_stream);
                        tagData.Name = name;
                        _parent.Tags.Add(tagData);
                        PushParent(tagData);
                    }
                    else
                    {
                        var tagReader = TagReaderResolver.GetTagReader(tagType);
                        var tagData = tagReader.ReadTag(_stream);
                        tagData.Name = name;
                        _parent.Tags.Add(tagData);
                    }

                    if (_isParentList) //at the end we check if list ended
                    {
                        if (_listParent.Tags.Count == _listParent.PayloadSize)
                        {
                            PopParent();
                        }
                    }
                }
            }

            return rootTag;
        }

        private CompoundTagData ReadRootTag()
        {
            const int firstTagStreamPosition = 0;
            const int rootPayloadStreamPosition = 3;

            var rootTagType = GetTagType(firstTagStreamPosition);

            if (rootTagType != NbtTagType.Compound)
                throw new NbtTagReadException("Document first tag is not compound.", firstTagStreamPosition);

            _stream.Seek(rootPayloadStreamPosition, SeekOrigin.Begin);

            return new CompoundTagData();
        }

        private void PopParent()
        {
            _parent = _parents.Pop();
            _isParentList = _parent.IsList();

            if (_isParentList)
                _listParent = (ListTagData)_parent;
        }

        private void PushParent(ICollectionTagData collectionTagData)
        {
            _parents.Push(_parent);
            _parent = collectionTagData;
            _isParentList = collectionTagData.IsList();
            
            if(_isParentList)
                _listParent = (ListTagData)collectionTagData;
        }

        private NbtTagType GetTagType(long tagPosition)
        {
            var typeByte = _stream.ReadByte();

            if (typeByte < 0)
                throw new EndOfStreamException();

            if (typeByte > 12)
                throw new NbtTagReadException($"Type byte value invalid: {typeByte}", tagPosition);

            return (NbtTagType)typeByte;
        }
    }
}
