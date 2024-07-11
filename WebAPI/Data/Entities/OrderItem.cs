namespace WebAPI.Data.Entities;

public class OrderItem
{
    
    public Guid Id { get; set; }

    public long OrderId
    {
        get; set;
    }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }

    public decimal Amount { get; set; }
    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
}