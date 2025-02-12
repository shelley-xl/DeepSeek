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

    [Fact]
    public async Task Test()
    {
        var cancellationToken = new CancellationTokenSource();

        var request = new ChatRequest
        {
            Messages = [Message.NewUserMessage("你好")],
            Model = Constants.Models.ChatModel,
        };

        var choices = _deepSeekService.ChatStreamAsync(request, cancellationToken.Token);

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

        var balance = await _deepSeekService.GetUserBalanceAsync(cancellationToken.Token);
        
        if (balance is null)
        {
            Debug.WriteLine(_deepSeekService.ErrorMessage);
        }

        Assert.NotNull(balance);

        Debug.WriteLine("\r\n");
        Debug.WriteLine($"账户余额：{balance.BalanceInfos?.FirstOrDefault()?.TotalBalance}");
        Debug.WriteLine("\r\n");
    }
}
