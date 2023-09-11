using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;
using Domain.Entities.Identity;

namespace Domain.Entities;

public class Order: BaseEntity
{
    public string CustomerId { get; set; }
    
    public AppUser Customer { get; set; }
    
    public string MovieId { get; set; }
    public Movie Movie { get; set; }
    
    [Column(TypeName = "decimal(18, 2)")]
    
    public decimal Price { get; set; }
    public DateTime HiringDateTime { get; set; }
}