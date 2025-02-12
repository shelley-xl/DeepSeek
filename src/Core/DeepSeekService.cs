namespace DeepSeek.Core;

/// <summary>
/// DeepSeek服务实现
/// </summary>
public class DeepSeekService(IHttpClientFactory factory) : IDeepSeekService
{
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="request">聊天请求</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public async IAsyncEnumerable<Choice?> ApiChatStreamAsync(ApiChatRequest request, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // 设置SSE
        request.Stream = true;

        // 创建DeepSeek客户端
        var client = factory.CreateClient(Constants.ClientNames.DeepSeekClient);

        // 序列化请求内容
        var content = new StringContent(JsonSerializer.Serialize(request, JsonSerializerOptions), Encoding.UTF8, "application/json");

        // 请求消息
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, Constants.Endpoints.ChatEndpoint)
        {
            Content = content,
        };

        // 请求响应
        using var response = await client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            // 响应失败
            var res = await response.Content.ReadAsStringAsync(cancellationToken);

            _ErrorMessage = $"{response.StatusCode}:{res}";

            yield break;
        }

        // 响应成功
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

        using var reader = new StreamReader(stream);

        while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
        {
            var line = await reader.ReadLineAsync(cancellationToken);
            if (line != null && line.StartsWith("data: "))
            {
                var json = line[6..];
                if (!string.IsNullOrWhiteSpace(json) && json != "[DONE]")
                {
                    var chatResponse = JsonSerializer.Deserialize<ChatDto>(json, JsonSerializerOptions);
                    var choice = chatResponse?.Choices?.FirstOrDefault();
                    if (choice is null)
                    {
                        continue;
                    }
                    yield return choice;
                }
            }
        }
    }

    /// <summary>
    /// 获取账户余额
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public async Task<BalanceDto?> ApiGetUserBalanceAsync(CancellationToken cancellationToken)
    {
        // 创建DeepSeek客户端
        var client = factory.CreateClient(Constants.ClientNames.DeepSeekClient);

        var response = await client.GetAsync(Constants.Endpoints.UserBalanceEndpoint, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadAsStringAsync(cancellationToken);
            _ErrorMessage = $"{response.StatusCode}:{res}";
            return null;
        }

        var result = await response.Content.ReadFromJsonAsync<BalanceDto?>(JsonSerializerOptions, cancellationToken);

        if (result is null)
        {
            _ErrorMessage = "响应结果为空";
        }

        return result;
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="request">聊天请求</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    public async IAsyncEnumerable<StreamingKernelContent?> OllamaChatStreamingAsync(OllamaChatRequest request, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.ModelId))
        {
            _ErrorMessage = "ModelId不能为空";
            yield break;
        }

        if (string.IsNullOrEmpty(request.BaseUrl))
        {
            _ErrorMessage = "BaseUrl不能为空";
            yield break;
        }

        if (string.IsNullOrEmpty(request.PromptTemplate))
        {
            _ErrorMessage = "PromptTemplate不能为空";
            yield break;
        }

        var builder = Kernel
            .CreateBuilder()
            .AddOllamaChatCompletion(request.ModelId, request.BaseUrl);

        builder.Services.AddScoped<HttpClient>();

        var kernel = builder.Build();

        var response = kernel.InvokePromptStreamingAsync(request.PromptTemplate, cancellationToken: cancellationToken);

        await foreach (var result in response)
        {
            yield return result;
        }
    }

    /// <summary>
    /// 错误消息
    /// </summary>
    public string? ErrorMessage => _ErrorMessage;

    string? _ErrorMessage = null;

    readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    };
}
