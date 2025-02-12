namespace DeepSeek.Dtos;

/// <summary>
/// 账户余额响应
/// </summary>
public class BalanceDto
{
    /// <summary>
    /// has balance
    /// </summary>
    [JsonPropertyName("is_available")]
    public bool? IsAvailable { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("balance_infos")]
    public List<UserBalance>? BalanceInfos { get; set; }
}
