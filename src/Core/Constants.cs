namespace DeepSeek.Core;

/// <summary>
/// 常量
/// </summary>
public class Constants
{
    /// <summary>
    /// 模型
    /// </summary>
    public class OllamaModels
    {
        /// <summary>
        /// deepseek-r1
        /// </summary>
        public const string DeepSeek_R1_latest = "deepseek-r1";

        /// <summary>
        /// deepseek-r1:1.5b
        /// </summary>
        public const string DeepSeek_R1_1_5b = "deepseek-r1:1.5b";

        /// <summary>
        /// deepseek-r1:7b
        /// </summary>
        public const string DeepSeek_R1_7b = "deepseek-r1:7b";

        /// <summary>
        /// deepseek-r1:8b
        /// </summary>
        public const string DeepSeek_R1_8b = "deepseek-r1:8b";

        /// <summary>
        /// deepseek-r1:14b
        /// </summary>
        public const string DeepSeek_R1_14b = "deepseek-r1:14b";

        /// <summary>
        /// deepseek-r1:32b
        /// </summary>
        public const string DeepSeek_R1_32b = "deepseek-r1:32b";

        /// <summary>
        /// deepseek-r1:70b
        /// </summary>
        public const string DeepSeek_R1_70b = "deepseek-r1:70b";

        /// <summary>
        /// deepseek-r1:671b
        /// </summary>
        public const string DeepSeek_R1_671b = "deepseek-r1:671b";
    }

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
        public const string ChatEndpoint = "/chat/completions";

        /// <summary>
        /// 
        /// </summary>
        public const string CompletionEndpoint = "/completions";

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
