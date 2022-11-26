namespace CarService.Entities.Models;

public class CarService: BaseEntity
{
    public string? Address { get; set; }
    public string? WorkSchedule { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Description { get; set; }
    public string? City { get; set; }

    public virtual Guid IdOwnerOfCarService { get; set;}
    public virtual OwnerOfCarService? OwnerOfCarService { get; set; }
    
     public virtual ICollection<ReviewForCarService>? ReviewsForCarService { get; set; }
     public virtual ICollection<ServiceOfCarService>? ServicesOfCarService { get; set; }
}