using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiIspitApp.Models;

public partial class OrderItem : ObservableObject
{
    public Guid Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }

    public decimal Price { get; set; }

    // public int Quantity { get; set; }
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
    private int _quantity;

    public decimal Amount => Price * Quantity;
}