var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
   .SetBasePath(AppContext.BaseDirectory)
   .AddJsonFile($"appsettings.json", true, true)
   .Build();

services.AddSingleton<IConfiguration>(configuration);
services.AddDeepSeekClient();

var provider = services.BuildServiceProvider();

var deepSeekService = provider.GetRequiredService<IDeepSeekService>();

while (true)
{
    Console.WriteLine();
    Console.Write("请输入：");

    var input = Console.ReadLine();

    if (string.IsNullOrEmpty(input))
    {
        continue;
    }

    Console.WriteLine();
    Console.Write("正在思考，请稍后...");
    Console.WriteLine();
    Console.WriteLine();

    var request = new ApiChatRequest
    {
        Messages = [Message.NewUserMessage(input)],
        Model = Constants.Models.ChatModel,
    };

    var cancellationToken = new CancellationTokenSource();

    var choices = deepSeekService.ApiChatStreamAsync(request, cancellationToken.Token);

    await foreach (var choice in choices)
    {
        Console.Write(choice?.Delta?.Content);
    }

    if (deepSeekService.ErrorMessage is not null)
    {
        Console.WriteLine(deepSeekService.ErrorMessage);
        continue;
    }

    Console.WriteLine();

    var balance = await deepSeekService.ApiGetUserBalanceAsync(cancellationToken.Token);
    
    if (deepSeekService.ErrorMessage is not null)
    {
        Console.WriteLine(deepSeekService.ErrorMessage);
        continue;
    }

    Console.WriteLine();
    Console.WriteLine($"账户余额：{balance?.BalanceInfos?.FirstOrDefault()?.TotalBalance}");
}
