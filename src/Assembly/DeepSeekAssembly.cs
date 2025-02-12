global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Text;
global using System.Text.Encodings.Web;
global using System.Text.Unicode;
global using System.Net.Http.Json;
global using System.Runtime.CompilerServices;
global using DeepSeek.Core;
global using DeepSeek.Dtos;
global using DeepSeek.Dtos.Request;
global using DeepSeek.Models;

namespace DeepSeek.Assembly;

/// <summary>
/// DeepSeek程序集
/// </summary>
public class DeepSeekAssembly
{
    /// <summary>
    /// 程序集对象
    /// </summary>
    public static readonly System.Reflection.Assembly Assembly = System.Reflection.Assembly.GetExecutingAssembly();

    /// <summary>
    /// 程序集名称
    /// </summary>
    public static readonly string Name = Assembly.GetName().Name!;

    /// <summary>
    /// 程序集版本号
    /// </summary>
    public static readonly string Version = Assembly.GetName().Version!.ToString();
}
