namespace DeepSeek.Core;

/// <summary>
/// 常量
/// </summary>
public class Constants
{
    /// <summary>
    /// 接口地址
    /// </summary>
    public class BaseUrls
    {
        /// <summary>
        /// 
        /// </summary>
        public const string BaseUrl = "https://api.deepseek.com";
    }

    /// <summary>
    /// 客户端名称
    /// </summary>
    public class ClientNames
    {
        /// <summary>
        /// 
        /// </summary>
        public const string DeepSeekClient = "deepseek";
    }

    /// <summary>
    /// Endpoints
    /// </summary>
    public class Endpoints
    {
        /// <summary>
        /// 
        /// </summary>
        public const string ChatEndpoint  = "/chat/completions";

        /// <summary>
        /// 
        /// </summary>
        public const string CompletionEndpoint  = "/completions";

        /// <summary>
        /// 
        /// </summary>
        public const string UserBalanceEndpoint = "/user/balance";

        /// <summary>
        /// 
        /// </summary>
        public const string ModelsEndpoint = "/models";
    }

    /// <summary>
    /// 模型
    /// </summary>
    public class Models
    {
        /// <summary>
        /// 聊天模型
        /// </summary>
        public const string ChatModel = "deepseek-chat";

        /// <summary>
        /// 推理模型
        /// </summary>
        public const string ReasonerModel = "deepseek-reasoner";
    }

    /// <summary>
    /// 响应格式
    /// </summary>
    public class ResponseFormatTypes
    {
        /// <summary>
        /// 文本
        /// </summary>
        public const string Text = "text";

        /// <summary>
        /// JSON
        /// </summary>
        public const string JsonObject = "json_object";
    }
}
