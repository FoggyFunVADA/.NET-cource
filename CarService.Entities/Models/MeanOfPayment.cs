namespace CarService.Entities.Models;

public class MeanOfPayment: BaseEntity
{
    public string? NameOfMeanOfPayment { get; set; }

     public virtual ICollection<User>? Users { get; set; }
}