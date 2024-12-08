using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace FsgXmk.Kaitai.Extensions.DependencyInjection
{
    public static class FsgXmkKaitaiServiceCollectionExtensions
    {
        public static IServiceCollection AddFsgXmkKaitai(this IServiceCollection services)
        {
            return services.AddSingleton<IXmkHeaderByteArrayReaderFactory, KaitaiXmkHeaderByteArrayReaderFactory>()
                           .AddSingleton<IXmkTempoByteArrayReaderFactory, KaitaiXmkTempoByteArrayReaderFactory>()
                           .AddSingleton<IXmkTimeSignatureByteArrayReaderFactory, KaitaiXmkTimeSignatureByteArrayReaderFactory>()
                           .AddSingleton<IXmkEventByteArrayReaderFactory, KaitaiXmkEventByteArrayReaderFactory>()
                           .AddSingleton<IXmkBlobsByteArrayReaderFactory, KaitaiXmkBlobsByteArrayReaderFactory>()
                           .AddSingleton<IXmkHeaderStreamReaderFactory, KaitaiXmkHeaderStreamReaderFactory>()
                           .AddSingleton<IXmkTempoStreamReaderFactory, KaitaiXmkTempoStreamReaderFactory>()
                           .AddSingleton<IXmkTimeSignatureStreamReaderFactory, KaitaiXmkTimeSignatureStreamReaderFactory>()
                           .AddSingleton<IXmkEventStreamReaderFactory, KaitaiXmkEventStreamReaderFactory>()
                           .AddSingleton<IXmkBlobsStreamReaderFactory, KaitaiXmkBlobsStreamReaderFactory>()
                           .AddSingleton<IXmkStreamReaderFactory, KaitaiXmkStreamReaderFactory>();
        }
    }
}
