using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.IO;
using Kaitai;
using System.Threading.Tasks;

namespace FsgXmk.Kaitai.IO
{
    public class KaitaiXmkTempoStreamReader : IXmkTempoReader
    {
        private readonly KaitaiStream _stream;
        private readonly bool _leaveOpen;
        private bool _disposed;

        public KaitaiXmkTempoStreamReader(KaitaiStream stream) : this(stream, false)
        {
        }

        public KaitaiXmkTempoStreamReader(KaitaiStream stream, bool leaveOpen)
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
            return new Xmk.XmkTempo(_stream);
        }

        public Task<IXmkTempo> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
