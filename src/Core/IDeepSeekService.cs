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
    /// <param name="cancellationToken">取消token</param>
    /// <returns></returns>
    IAsyncEnumerable<Choice?> ChatStreamAsync(ChatRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// 获取账户余额
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<BalanceDto?> GetUserBalanceAsync(CancellationToken cancellationToken);
}
