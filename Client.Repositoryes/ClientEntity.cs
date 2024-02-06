using Client.Contracts;

namespace Client.Repositories;
/// <summary>
/// Клиенты репозитория.
/// </summary>
public class ClientEntity
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int id { get; set; }
    
    /// <summary>
    /// Имя клиента.
    /// </summary>
    public string Name { get; set; }
}