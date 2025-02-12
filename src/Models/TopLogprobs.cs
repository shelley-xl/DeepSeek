namespace DeepSeek.Models;

/// <summary>
/// 
/// </summary>
public class TopLogprobs
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
}
