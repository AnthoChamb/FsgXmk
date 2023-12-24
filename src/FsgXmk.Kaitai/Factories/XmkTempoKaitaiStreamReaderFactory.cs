﻿using FsgXmk.Core.Interfaces.Factories;
using FsgXmk.Core.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class XmkTempoKaitaiStreamReaderFactory : IXmkTempoStreamReaderFactory
    {
        public IXmkTempoReader Create(Stream stream, bool leaveOpen)
        {
            return new XmkTempoKaitaiStreamReader(new KaitaiStream(stream), leaveOpen);
        }
    }
}
