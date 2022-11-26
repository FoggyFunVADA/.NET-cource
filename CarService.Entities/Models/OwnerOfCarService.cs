namespace CarService.Entities.Models;

public class OwnerOfCarService: BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    
     public virtual ICollection<CarService>? CarServices { get; set; }
}