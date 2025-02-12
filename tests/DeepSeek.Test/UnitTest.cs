namespace DeepSeek.Test;

public class UnitTest
{
    readonly IDeepSeekService _deepSeekService;

    public UnitTest()
    {
        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
           .SetBasePath(AppContext.BaseDirectory)
           .AddJsonFile($"appsettings.json", true, true)
           .Build();

        services.AddSingleton<IConfiguration>(configuration);
        services.AddDeepSeekClient();

        var provider = services.BuildServiceProvider();

        _deepSeekService = provider.GetRequiredService<IDeepSeekService>();
    }

    [Fact(DisplayName = "Api 测试")]
    public async Task TestApi()
    {
        var cancellationToken = new CancellationTokenSource();

        var request = new ApiChatRequest
        {
            Messages = [Message.NewUserMessage("你好")],
            Model = Constants.Models.ChatModel,
        };

        var choices = _deepSeekService.ApiChatStreamAsync(request, cancellationToken.Token);

        if (choices is null)
        {
            Debug.WriteLine(_deepSeekService.ErrorMessage);
        }

        Assert.NotNull(choices);

        Debug.WriteLine("\r\n");
        Debug.WriteLine("正在思考，请稍后...");
        Debug.WriteLine("\r\n");

        var index = 0;

        await foreach (var choice in choices)
        {
            if (index == 0)
            {
                Debug.WriteLine("\r\n");
            }

            Debug.Write(choice?.Delta?.Content);

            index++;
        }

        Debug.WriteLine("\r\n");

        var balance = await _deepSeekService.ApiGetUserBalanceAsync(cancellationToken.Token);

        if (balance is null)
        {
            Debug.WriteLine(_deepSeekService.ErrorMessage);
        }

        Assert.NotNull(balance);

        Debug.WriteLine("\r\n");
        Debug.WriteLine($"账户余额：{balance.BalanceInfos?.FirstOrDefault()?.TotalBalance}");
        Debug.WriteLine("\r\n");
    }

    [Fact(DisplayName = "Ollama 测试")]
    public async Task TestOllama()
    {
        var cancellationToken = new CancellationTokenSource();

        var request = new OllamaChatRequest
        {
            ModelId = Constants.OllamaModels.DeepSeek_R1_7b,
            BaseUrl = "http://localhost:11434",
            PromptTemplate = "你好",
        };

        var response = _deepSeekService.OllamaChatStreamingAsync(request, cancellationToken.Token);

        if (response is null)
        {
            Debug.WriteLine(_deepSeekService.ErrorMessage);
        }

        Assert.NotNull(response);

        Debug.WriteLine("\r\n");
        Debug.WriteLine("正在思考，请稍后...");
        Debug.WriteLine("\r\n");

        var index = 0;

        await foreach (var result in response)
        {
            if (index == 0)
            {
                Debug.WriteLine("\r\n");
            }

            Debug.Write(result);

            index++;
        }

        Debug.WriteLine("\r\n");
    }
}
