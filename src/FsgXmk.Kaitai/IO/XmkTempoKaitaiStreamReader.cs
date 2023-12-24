using FsgXmk.Core.Interfaces;
using FsgXmk.Core.Interfaces.IO;
using Kaitai;
using System.Threading.Tasks;

namespace FsgXmk.Kaitai.IO
{
    public class XmkTempoKaitaiStreamReader : IXmkTempoReader
    {
        private readonly KaitaiStream _stream;
        private readonly bool _leaveOpen;
        private bool _disposed;

        public XmkTempoKaitaiStreamReader(KaitaiStream stream) : this(stream, false)
        {
        }

        public XmkTempoKaitaiStreamReader(KaitaiStream stream, bool leaveOpen)
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

        public IXmkTempo Read()
        {
            return new FsgXmk.XmkTempo(_stream);
        }

        public Task<IXmkTempo> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
