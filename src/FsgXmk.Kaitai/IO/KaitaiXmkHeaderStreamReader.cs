using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.IO;
using Kaitai;
using System.Threading.Tasks;

namespace FsgXmk.Kaitai.IO
{
    public class KaitaiXmkHeaderStreamReader : IXmkHeaderReader
    {
        private readonly KaitaiStream _stream;
        private readonly bool _leaveOpen;
        private bool _disposed;

        public KaitaiXmkHeaderStreamReader(KaitaiStream stream) : this(stream, false)
        {
        }

        public KaitaiXmkHeaderStreamReader(KaitaiStream stream, bool leaveOpen)
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

        public IXmkHeader Read()
        {
            return new Xmk.XmkHeader(_stream);
        }

        public Task<IXmkHeader> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
