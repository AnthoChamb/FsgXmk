using FsgXmk.Core.Interfaces;
using FsgXmk.Core.Interfaces.IO;
using Kaitai;
using System.Threading.Tasks;

namespace FsgXmk.Kaitai.IO
{
    public class FsgXmkKaitaiStreamReader : IFsgXmkReader
    {
        private readonly KaitaiStream _stream;
        private readonly bool _leaveOpen;
        private bool _disposed;

        public FsgXmkKaitaiStreamReader(KaitaiStream stream) : this(stream, false)
        {
        }

        public FsgXmkKaitaiStreamReader(KaitaiStream stream, bool leaveOpen)
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

        public IFsgXmk Read()
        {
            return new FsgXmk(_stream);
        }

        public Task<IFsgXmk> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
