using FsgXmk.Core.Interfaces.Factories;
using FsgXmk.Extensions.DependencyInjection;
using FsgXmk.Kaitai.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace FsgXmk.Kaitai.Extensions.DependencyInjection
{
    public static class KaitaiFsgXmkBuilderExtensions
    {
        public static FsgXmkBuilder AddKaitai(this FsgXmkBuilder builder)
        {
            builder.Services.AddSingleton<IFsgXmkStreamReaderFactory, FsgXmkKaitaiStreamReaderFactory>();
            builder.Services.AddSingleton<IXmkEventStreamReaderFactory, XmkEventKaitaiStreamReaderFactory>();
            builder.Services.AddSingleton<IXmkHeaderStreamReaderFactory, XmkHeaderKaitaiStreamReaderFactory>();
            builder.Services.AddSingleton<IXmkTempoStreamReaderFactory, XmkTempoKaitaiStreamReaderFactory>();
            builder.Services.AddSingleton<IXmkTimeSignatureStreamReaderFactory, XmkTimeSignatureKaitaiStreamReaderFactory>();
            return builder;
        }
    }
}
