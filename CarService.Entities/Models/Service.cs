namespace CarService.Entities.Models;

public class Service : BaseEntity
{
    public string? NameOfService { get; set; }
    
     public virtual ICollection<ServiceOfCarService>? ServicesOfCarService { get; set; }
}