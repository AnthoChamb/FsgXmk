﻿using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class KaitaiXmkEventStreamReaderFactory : IXmkEventStreamReaderFactory
    {
        public IXmkEventReader Create(Stream stream, bool leaveOpen)
        {
            return new KaitaiXmkEventStreamReader(new KaitaiStream(stream), leaveOpen);
        }
    }
}
