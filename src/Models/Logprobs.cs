namespace DeepSeek.Models;

/// <summary>
/// 对数概率信息
/// </summary>
public class Logprobs
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("text_offset")]
    public int[]? TextOffset { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string[]? Tokens { get; set; } = [];

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("token_logprobs")]
    public double[]? TokenLogProbs { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("top_logprobs")]
    public List<TopLogprobs>? TopLogProbs { get; set; }

    /// <summary>
    /// 包含输出 token 对数概率信息的列表
    /// </summary>
    public List<Content> Content { get; set; } = [];
}
