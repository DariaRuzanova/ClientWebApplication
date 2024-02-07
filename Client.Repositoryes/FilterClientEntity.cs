namespace Client.Services;

public class FilterClientEntity
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int ClientId { get; set; }
    
    /// <summary>
    /// Имя клиента.
    /// </summary>
    public string FullName { get; set; }
}