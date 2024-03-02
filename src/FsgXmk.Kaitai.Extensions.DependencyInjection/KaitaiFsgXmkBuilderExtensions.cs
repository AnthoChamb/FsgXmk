﻿using FsgXmk.Core.Interfaces.Factories;
using FsgXmk.Extensions.DependencyInjection;
using FsgXmk.Kaitai.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace FsgXmk.Kaitai.Extensions.DependencyInjection
{
    public static class KaitaiFsgXmkBuilderExtensions
    {
        public static FsgXmkBuilder AddKaitai(this FsgXmkBuilder builder)
        {
            builder.Services.AddSingleton<IXmkStreamReaderFactory, KaitaiXmkStreamReaderFactory>();
            builder.Services.AddSingleton<IXmkEventStreamReaderFactory, KaitaiXmkEventStreamReaderFactory>();
            builder.Services.AddSingleton<IXmkHeaderStreamReaderFactory, KaitaiXmkHeaderStreamReaderFactory>();
            builder.Services.AddSingleton<IXmkTempoStreamReaderFactory, KaitaiXmkTempoStreamReaderFactory>();
            builder.Services.AddSingleton<IXmkTimeSignatureStreamReaderFactory, KaitaiXmkTimeSignatureStreamReaderFactory>();
            return builder;
        }
    }
}
