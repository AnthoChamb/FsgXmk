using FsgXmk.Abstractions.Interfaces.IO;
using Kaitai;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FsgXmk.Kaitai.IO
{
    public class KaitaiXmkBlobsStreamReader : IXmkBlobsReader
    {
        private readonly KaitaiStream _stream;
        private readonly bool _leaveOpen;
        private bool _disposed;

        public KaitaiXmkBlobsStreamReader(KaitaiStream stream) : this(stream, false)
        {
        }

        public KaitaiXmkBlobsStreamReader(KaitaiStream stream, bool leaveOpen)
        {
            _stream = stream;
            _leaveOpen = leaveOpen;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (!_leaveOpen)
                {
                    _stream.Dispose();
                }
                _disposed = true;
            }
        }

        public IEnumerable<string> Read(uint blobsLength)
        {
            var bytes = _stream.ReadBytes(blobsLength);
            var stream = new KaitaiStream(bytes);
            var blobs = new Xmk.XmkBlobs(stream);
            return blobs.Values;
        }

        public ValueTask<IEnumerable<string>> ReadAsync(uint blobsLength)
        {
            return new ValueTask<IEnumerable<string>>(Read(blobsLength));
        }
    }
}
