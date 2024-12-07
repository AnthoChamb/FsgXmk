using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace FsgXmk.Kaitai.Extensions.DependencyInjection
{
    public static class FsgXmkKaitaiServiceCollectionExtensions
    {
        public static IServiceCollection AddFsgXmkKaitai(this IServiceCollection services)
        {
            return services.AddSingleton<IXmkStreamReaderFactory, KaitaiXmkStreamReaderFactory>()
                           .AddSingleton<IXmkEventStreamReaderFactory, KaitaiXmkEventStreamReaderFactory>()
                           .AddSingleton<IXmkHeaderStreamReaderFactory, KaitaiXmkHeaderStreamReaderFactory>()
                           .AddSingleton<IXmkTempoStreamReaderFactory, KaitaiXmkTempoStreamReaderFactory>()
                           .AddSingleton<IXmkTimeSignatureStreamReaderFactory, KaitaiXmkTimeSignatureStreamReaderFactory>();
        }
    }
}
