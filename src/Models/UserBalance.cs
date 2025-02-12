namespace DeepSeek.Models;

/// <summary>
/// 账户余额
/// </summary>
public class UserBalance
{
    /// <summary>
    /// CNY or USD
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("total_balance")]
    public string? TotalBalance { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("granted_balance")]
    public string? GrantedBalance { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("topped_up_balance")]
    public string? ToppedUpBalance { get; set; }
}
