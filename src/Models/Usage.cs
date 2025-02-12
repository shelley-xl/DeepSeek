namespace DeepSeek.Models;

/// <summary>
/// 用量信息
/// </summary>
public class Usage
{
    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("completion_tokens")]
    public int? CompletionTokens { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("prompt_tokens")]
    public int? PromptTokens { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("prompt_cache_hit_tokens")]
    public int? PromptCacheHitTokens { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("prompt_cache_miss_tokens")]
    public int? PromptCacheMissTokens { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("total_tokens")]
    public int? TotalTokens { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("prompt_tokens_details")]
    public CompletionTokensDetails? Details { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public class CompletionTokensDetails
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("reasoning_tokens")]
        public int? ReasoningTokens { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("cached_tokens")]
        public int? CachedTokens { get; set; }
    }
}
