using FsgXmk.Core.Interfaces;
using FsgXmk.Core.Interfaces.IO;
using Kaitai;
using System.Threading.Tasks;

namespace FsgXmk.Kaitai.IO
{
    public class XmkEventKaitaiStreamReader : IXmkEventReader
    {
        private readonly KaitaiStream _stream;
        private readonly bool _leaveOpen;
        private bool _disposed;

        public XmkEventKaitaiStreamReader(KaitaiStream stream) : this(stream, false)
        {
        }

        public XmkEventKaitaiStreamReader(KaitaiStream stream, bool leaveOpen)
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

        public IXmkEvent Read()
        {
            return new FsgXmk.XmkEvent(_stream);
        }

        public Task<IXmkEvent> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
