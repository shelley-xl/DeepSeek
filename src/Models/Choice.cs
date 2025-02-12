namespace DeepSeek.Models;

/// <summary>
/// 模型生成的选择
/// </summary>
public class Choice
{
    /// <summary>
    /// FinishReason
    /// </summary>
    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? Index { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Message? Message { get; set; }

    /// <summary>
    /// 该 choice 的对数概率信息。
    /// </summary>
    public Logprobs? Logprobs { get; set; }

    /// <summary>
    /// use this when streaming 
    /// </summary>
    public Message? Delta { get; set; }

    /// <summary>
    /// for completion 
    /// </summary>
    public string? Text { get; set; }
}
