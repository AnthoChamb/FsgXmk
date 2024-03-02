using FsgXmk.Core.Interfaces;
using FsgXmk.Core.Interfaces.IO;
using Kaitai;
using System.Threading.Tasks;

namespace FsgXmk.Kaitai.IO
{
    public class KaitaiXmkStreamReader : IXmkReader
    {
        private readonly KaitaiStream _stream;
        private readonly bool _leaveOpen;
        private bool _disposed;

        public KaitaiXmkStreamReader(KaitaiStream stream) : this(stream, false)
        {
        }

        public KaitaiXmkStreamReader(KaitaiStream stream, bool leaveOpen)
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

        public IXmk Read()
        {
            return new Xmk(_stream);
        }

        public Task<IXmk> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
