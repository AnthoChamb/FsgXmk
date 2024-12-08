using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace FsgXmk.Extensions.DependencyInjection
{
    public static class FsgXmkServiceCollectionExtensions
    {
        public static IServiceCollection AddFsgXmk(this IServiceCollection services)
        {
            return services.AddSingleton<IXmkHeaderByteArrayReaderFactory, XmkHeaderByteArrayReaderFactory>()
                           .AddSingleton<IXmkTempoByteArrayReaderFactory, XmkTempoByteArrayReaderFactory>()
                           .AddSingleton<IXmkTimeSignatureByteArrayReaderFactory, XmkTimeSignatureByteArrayReaderFactory>()
                           .AddSingleton<IXmkEventByteArrayReaderFactory, XmkEventByteArrayReaderFactory>()
                           .AddSingleton<IXmkBlobsByteArrayReaderFactory, XmkBlobsByteArrayReaderFactory>()
                           .AddSingleton<IXmkHeaderStreamReaderFactory, XmkHeaderStreamReaderFactory>()
                           .AddSingleton<IXmkTempoStreamReaderFactory, XmkTempoStreamReaderFactory>()
                           .AddSingleton<IXmkTimeSignatureStreamReaderFactory, XmkTimeSignatureStreamReaderFactory>()
                           .AddSingleton<IXmkEventStreamReaderFactory, XmkEventStreamReaderFactory>()
                           .AddSingleton<IXmkBlobsStreamReaderFactory, XmkBlobsStreamReaderFactory>()
                           .AddSingleton<IXmkStreamReaderFactory, XmkStreamReaderFactory>();
        }
    }
}
