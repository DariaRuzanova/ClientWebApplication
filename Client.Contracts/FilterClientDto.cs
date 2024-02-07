namespace WebApplication4.Controllers;

/// <summary>
/// Информация о клиентах.
/// </summary>
public class FilterClientDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string FullName { get; set; }
}