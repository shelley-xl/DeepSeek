namespace DeepSeek.Models;

/// <summary>
/// 
/// </summary>
public class Message
{
    /// <summary>
    /// 
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// beta feature
    /// </summary>
    public bool? Prefix { get; set; }

    /// <summary>
    /// beta feature
    /// </summary>
    [JsonPropertyName("reasoning_content")]
    public string? ReasoningContent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("tool_call_id")]
    public string? ToolCallId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Message NewUserMessage(string content)
    {
        return new Message
        {
            Content = content,
            Role = "user"
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Message NewSystemMessage(string content)
    {
        return new Message
        {
            Content = content,
            Role = "system"
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <param name="prefix"></param>
    /// <param name="reasoningContent"></param>
    /// <returns></returns>
    public static Message NewAssistantMessage(string content, bool? prefix, string? reasoningContent)
    {
        return new Message
        {
            Content = content,
            Role = "assistant",
            Prefix = prefix,
            ReasoningContent = reasoningContent
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="content"></param>
    /// <param name="toolCallId"></param>
    /// <returns></returns>
    public static Message NewToolMessage(string content, string toolCallId)
    {
        return new Message
        {
            Content = content,
            Role = "tool",
            ToolCallId = toolCallId
        };
    }
}
