using FsgXmk.Abstractions;
using FsgXmk.Abstractions.Interfaces.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsgXmk.IO
{
    public class XmkBlobsByteArrayReader : IXmkBlobsReader
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public XmkBlobsByteArrayReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public XmkBlobsByteArrayReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IEnumerable<string> Read(uint blobsLength)
        {
            if (blobsLength == 0)
            {
                return Enumerable.Empty<string>();
            }

            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count).Slice(0, (int) blobsLength);

            var blobs = new List<string>();
            var blobOffset = 0;

            while (!span.IsEmpty)
            {
                var terminatorIndex = span.IndexOf(XmkConstants.XmkBlobTerminator);
                if (terminatorIndex == -1)
                {
                    blobs.Add(Encoding.ASCII.GetString(_buffer, _offset + blobOffset, span.Length));
                    break;
                }
                else
                {
                    blobs.Add(Encoding.ASCII.GetString(_buffer, _offset + blobOffset, terminatorIndex));
                    blobOffset += terminatorIndex + 1;
                    span = span.Slice(terminatorIndex + 1);
                }
            }

            return blobs;
        }

        public ValueTask<IEnumerable<string>> ReadAsync(uint blobsLength)
        {
            return new ValueTask<IEnumerable<string>>(Read(blobsLength));
        }
    }
}
