var services = new ServiceCollection();

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

    var request = new OllamaChatRequest
    {
        ModelId = Constants.OllamaModels.DeepSeek_R1_7b,
        BaseUrl = "http://localhost:11434",
        PromptTemplate = input,
    };

    var cancellationToken = new CancellationTokenSource();

    var response = deepSeekService.OllamaChatStreamingAsync(request, cancellationToken.Token);

    await foreach (var result in response)
    {
        Console.Write(result);
    }

    if (deepSeekService.ErrorMessage is not null)
    {
        Console.WriteLine(deepSeekService.ErrorMessage);
        continue;
    }

    Console.WriteLine();
}
