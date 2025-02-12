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

    var request = new ChatRequest
    {
        Messages = [Message.NewUserMessage(input)],
        Model = Constants.Models.ChatModel,
    };

    var cancellationToken = new CancellationTokenSource();

    var choices = deepSeekService.ChatStreamAsync(request, cancellationToken.Token);

    if (choices is null)
    {
        Console.WriteLine(deepSeekService.ErrorMessage);
        continue;
    }

    await foreach (var choice in choices)
    {
        Console.Write(choice?.Delta?.Content);
    }

    Console.WriteLine();

    var balance = await deepSeekService.GetUserBalanceAsync(cancellationToken.Token);
    if (balance is null)
    {
        Console.WriteLine(deepSeekService.ErrorMessage);
        continue;
    }
    Console.WriteLine();
    Console.WriteLine($"账户余额：{balance.BalanceInfos?.FirstOrDefault()?.TotalBalance}");
}
