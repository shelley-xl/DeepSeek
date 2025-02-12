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

        var config = provider.GetRequiredService<IConfiguration>();

        var deepSeekOptions = config.GetSection("DeepSeek").Get<DeepSeekOptions>();

        if (deepSeekOptions == null || string.IsNullOrEmpty(deepSeekOptions.ApiKey)) return services;

        services.AddHttpClient(Constants.ClientNames.DeepSeekClient, client =>
        {
            client.BaseAddress = new Uri(Constants.BaseUrls.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(120);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + deepSeekOptions.ApiKey);
        });

        services.AddScoped<IDeepSeekService, DeepSeekService>();

        return services;
    }
}
