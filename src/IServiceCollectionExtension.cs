namespace DeepSeek;

/// <summary>
/// IServiceCollectionExtension
/// </summary>
public static class IServiceCollectionExtension
{
    /// <summary>
    /// 添加DeepSeek客户端
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDeepSeekClient(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();

        var config = provider.GetService<IConfiguration>();

        if (config != null)
        {
            var deepSeekOptions = config.GetSection("DeepSeek").Get<DeepSeekOptions>();

            if (deepSeekOptions != null && !string.IsNullOrEmpty(deepSeekOptions.ApiKey))
            {
                services.AddHttpClient(Constants.ClientNames.DeepSeekClient, client =>
                {
                    client.BaseAddress = new Uri(Constants.BaseUrls.BaseUrl);
                    client.Timeout = TimeSpan.FromSeconds(120);
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + deepSeekOptions.ApiKey);
                });
            }
        }
        else
        {
            services.AddHttpClient();
        }

        services.AddScoped<IDeepSeekService, DeepSeekService>();

        return services;
    }
}
