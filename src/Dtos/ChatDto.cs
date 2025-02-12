namespace DeepSeek.Dtos;

/// <summary>
/// 聊天响应
/// </summary>
public class ChatDto
{
    /// <summary>
    /// 该对话的唯一标识符。
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// 模型生成的 completion 的选择列表
    /// </summary>
    public List<Choice>? Choices { get; set; }

    /// <summary>
    /// 创建聊天完成时的 Unix 时间戳（以秒为单位）。
    /// </summary>
    public long? Created { get; set; }

    /// <summary>
    /// 生成该 completion 的模型名
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("system_fingerprint")]
    public string? SystemFingerprint { get; set; }

    /// <summary>
    /// 对象的类型, 其值为 chat.completion
    /// </summary>
    public string? Object { get; set; }

    /// <summary>
    /// 该对话补全请求的用量信息
    /// </summary>
    public Usage? Usage { get; set; }
}
