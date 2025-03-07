﻿using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.IO;
using Kaitai;
using System.Threading.Tasks;

namespace FsgXmk.Kaitai.IO
{
    public class KaitaiXmkEventStreamReader : IXmkEventReader
    {
        private readonly KaitaiStream _stream;
        private readonly bool _leaveOpen;
        private bool _disposed;

        public KaitaiXmkEventStreamReader(KaitaiStream stream) : this(stream, false)
        {
        }

        public KaitaiXmkEventStreamReader(KaitaiStream stream, bool leaveOpen)
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
            return new Xmk.XmkEvent(_stream);
        }

        public ValueTask<IXmkEvent> ReadAsync()
        {
            return new ValueTask<IXmkEvent>(Read());
        }
    }
}
