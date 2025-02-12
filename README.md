# DeepSeek

DeepSeek.NET 集成 Api/Ollama

[![Nuget](https://img.shields.io/nuget/v/DeepSeek.svg?style=flat-square)](https://www.nuget.org/packages/DeepSeek)
[![Downloads](https://img.shields.io/nuget/dt/DeepSeek.svg?style=flat-square)](https://www.nuget.org/stats/packages/DeepSeek?groupby=Version)
[![License](https://img.shields.io/github/license/shelley-xl/DeepSeek.svg)](https://github.com/shelley-xl/DeepSeek/blob/master/LICENSE)
![Vistors](https://visitor-badge.laobi.icu/badge?page_id=https://github.com/shelley-xl/DeepSeek)

## 安装

DeepSeek 以 NuGet 包的形式提供。您可以使用 NuGet 包控制台窗口安装它：

```
PM> Install-Package DeepSeek
```

## Api 使用示例

Program.cs

```c#
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
```

appsettings.json

```json
{
  "DeepSeek": {
    "ApiKey": "sk-xxxxxxxxxxxxxxxx"
  }
}
```

## Ollama 使用示例

```c#
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
```

## 更新日志

[CHANGELOG](CHANGELOG.md)
