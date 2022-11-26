namespace CarService.Entities.Models;

public class ServiceOfCarService: BaseEntity
{
    public double Cost { get; set; }

    public virtual Guid IdCarService { get; set; }
    public virtual CarService? CarService { get; set; }
    public virtual Guid IdService { get; set; }
    public virtual Service? Service { get; set; }
}