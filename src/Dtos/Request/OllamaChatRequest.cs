namespace DeepSeek.Dtos.Request;

/// <summary>
/// Ollama聊天请求
/// </summary>
public class OllamaChatRequest
{
    /// <summary>
    /// 模型Id
    /// </summary>
    public string? ModelId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? BaseUrl { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? PromptTemplate { get; set; }
}
