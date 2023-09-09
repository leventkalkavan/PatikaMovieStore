using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;
using Domain.Entities.Identity;

namespace Domain.Entities;

public class Order: BaseEntity
{
    public AppUser PurchasingCustomer { get; set; }
    public Movie PurchasingFilm { get; set; }
    
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
    public DateTime PurchaseDate { get; set; }
}