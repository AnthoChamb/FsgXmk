﻿using FsgXmk.Core.Interfaces.Factories;
using FsgXmk.Core.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class XmkEventKaitaiStreamReaderFactory : IXmkEventStreamReaderFactory
    {
        public IXmkEventReader Create(Stream stream, bool leaveOpen)
        {
            return new XmkEventKaitaiStreamReader(new KaitaiStream(stream), leaveOpen);
        }
    }
}
