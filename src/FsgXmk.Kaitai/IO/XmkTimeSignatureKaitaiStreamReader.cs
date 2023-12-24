using FsgXmk.Core.Interfaces;
using FsgXmk.Core.Interfaces.IO;
using Kaitai;
using System.Threading.Tasks;

namespace FsgXmk.Kaitai.IO
{
    public class XmkTimeSignatureKaitaiStreamReader : IXmkTimeSignatureReader
    {
        private readonly KaitaiStream _stream;
        private readonly bool _leaveOpen;
        private bool _disposed;

        public XmkTimeSignatureKaitaiStreamReader(KaitaiStream stream) : this(stream, false)
        {
        }

        public XmkTimeSignatureKaitaiStreamReader(KaitaiStream stream, bool leaveOpen)
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
            return new FsgXmk.XmkTimeSignature(_stream);
        }

        public Task<IXmkTimeSignature> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
