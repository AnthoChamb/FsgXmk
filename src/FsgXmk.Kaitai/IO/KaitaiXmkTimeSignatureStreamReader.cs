using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.IO;
using Kaitai;
using System.Threading.Tasks;

namespace FsgXmk.Kaitai.IO
{
    public class KaitaiXmkTimeSignatureStreamReader : IXmkTimeSignatureReader
    {
        private readonly KaitaiStream _stream;
        private readonly bool _leaveOpen;
        private bool _disposed;

        public KaitaiXmkTimeSignatureStreamReader(KaitaiStream stream) : this(stream, false)
        {
        }

        public KaitaiXmkTimeSignatureStreamReader(KaitaiStream stream, bool leaveOpen)
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

        public IXmkTimeSignature Read()
        {
            return new Xmk.XmkTimeSignature(_stream);
        }

        public ValueTask<IXmkTimeSignature> ReadAsync()
        {
            return new ValueTask<IXmkTimeSignature>(Read());
        }
    }
}
