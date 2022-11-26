namespace CarService.Entities.Models;

public class ReviewForCarService: BaseEntity
{
    public int Mark { get; set; }
    public string? Review { get; set; }

    public virtual Guid IdUser { get; set; }
    public virtual User? User { get; set; }
    public virtual Guid IdCarService { get; set; }
    public virtual CarService? CarService { get; set; }
}