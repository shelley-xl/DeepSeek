namespace DeepSeek.Core;

/// <summary>
/// DeepSeek服务接口
/// </summary>
public interface IDeepSeekService
{
    /// <summary>
    /// 错误消息
    /// </summary>
    abstract string? ErrorMessage { get; }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="request">聊天请求</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    IAsyncEnumerable<Choice?> ApiChatStreamAsync(ApiChatRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// 获取账户余额
    /// </summary>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    Task<BalanceDto?> ApiGetUserBalanceAsync(CancellationToken cancellationToken);

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="request">聊天请求</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    IAsyncEnumerable<StreamingKernelContent?> OllamaChatStreamingAsync(OllamaChatRequest request, CancellationToken cancellationToken);
}
