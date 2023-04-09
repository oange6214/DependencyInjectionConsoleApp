using ConfigServices;

namespace Microsoft.Extensions.DependencyInjection;

public static class IniFileConfigExtensions
{
    public static void AddIniFileConfig(this IServiceCollection services, string filePath)
    {
        services.AddScoped<IConfigService>(f => new IniFileConfigService { FilePath = filePath });
    }
}
