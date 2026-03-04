using Imu.ClientHttp;
using Imu.ClientHttp.Abstraction;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class UniprImuClientExtensions {

    public static IServiceCollection AddUniprImuClient(this IServiceCollection services, IConfiguration configuration) {

        IConfigurationSection confSection = configuration.GetSection(UniprImuClientOptions.SectionName);
        UniprImuClientOptions options = confSection.Get<UniprImuClientOptions>() ?? new();

        services.AddHttpClient<IClientHttp, ClientHttp>(o => {          
            o.BaseAddress = new Uri(options.BaseAddress);
        }).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
        });

        return services;
    }
}
