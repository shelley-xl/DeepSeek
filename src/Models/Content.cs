namespace DeepSeek.Models;

/// <summary>
/// 对数概率信息
/// </summary>
public class Content
{
    /// <summary>
    /// 
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public long? Logprob { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public byte[]? Bytes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("top_logprobs")]
    public List<TopLogprobs>? TopLogprobs { get; set; }
}
