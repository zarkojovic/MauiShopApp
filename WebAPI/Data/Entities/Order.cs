using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enumerations;

namespace WebAPI.Data.Entities;
[Table(nameof(Order))]
public class Order
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Placed;
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public virtual User User { get; set; }
}