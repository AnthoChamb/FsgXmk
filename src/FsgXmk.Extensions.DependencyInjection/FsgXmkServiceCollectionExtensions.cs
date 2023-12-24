using Microsoft.Extensions.DependencyInjection;

namespace FsgXmk.Extensions.DependencyInjection
{
    public static class FsgXmkServiceCollectionExtensions
    {
        public static FsgXmkBuilder AddFsgXmk(this IServiceCollection services)
        {
            return new FsgXmkBuilder(services);
        }
    }
}
