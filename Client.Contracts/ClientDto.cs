namespace Client.Contracts;
/// <summary>
/// Информация о клиентах.
/// </summary>
public class ClientDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }
}