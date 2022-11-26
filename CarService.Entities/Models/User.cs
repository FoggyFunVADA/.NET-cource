namespace CarService.Entities.Models;

public class User : BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? Email { get; set; }
    public string? City { get; set; }
    public string? PasswordHash { get; set; }

    public virtual Guid IdMeanOfPayment { get; set;}
    public virtual MeanOfPayment? MeanOfPayment { get; set; }
    
     public virtual ICollection<ReviewForCarService>? ReviewsForCarService { get; set; }
}