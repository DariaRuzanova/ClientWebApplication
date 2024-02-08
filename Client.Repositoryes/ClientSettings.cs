using System;

namespace Client.Repositories;
/// <summary>
/// Настройки сервиса клиентов.
/// </summary>
public class ClientSettings
{
    /// <summary>
    /// Адрес сервиса клиентов.
    /// </summary>
    public Uri ServiceAddress { get; set; } 
}