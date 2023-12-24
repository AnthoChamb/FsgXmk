using Microsoft.Extensions.DependencyInjection;

namespace FsgXmk.Extensions.DependencyInjection
{
    public class FsgXmkBuilder
    {
        public FsgXmkBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
