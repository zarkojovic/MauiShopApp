using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Data.Entities;

[Table(nameof(Offer))]
public class Offer
{
    [Key] public int Id { get; set; }
    [Required, MaxLength(150)] public string Title { get; set; }
    [Required, MaxLength(250)] public string Description { get; set; }
    [Required, MaxLength(10)] public string Code { get; set; }
    [Required, MaxLength(10)] public string BgColor { get; set; }
    public bool IsActive { get; set; }

    public Offer(int id,string title, string description, string bgColor, string code)
    {
        Id = id;
        Title = title;
        Description = description;
        Code = code;
        BgColor = bgColor;
    }

    private static readonly string[] _lightColors = new string[]
    {
        "#e1f1e7", "#dad1f9", "#ffff00", "#d0f200", "#e28083", "#7fbdc7", "#ea978d"
    };

    private static string RandomColor => _lightColors.OrderBy(c => Guid.NewGuid()).First();

    public static IEnumerable<Offer>  GetInitialData() => new List<Offer>
    {
        new(1,"Upto 30% off", "Enjoy upto 30% off on all fruits", RandomColor, "FRT30"),
        new(2,"Green Veg Big Sale 50% OFF", "Enjoy our big offer of 50% off on all green vegetables", RandomColor, "50OFF"),
        new(3,"Flat 100 OFF", "Flat Rs. 100 off on all exotic fruits and vegetables", RandomColor, "EXT100"),
        new(4,"25% OFF on Seasonal Fruits", "Enjoy 25% off on all seasonal fruits", RandomColor, "FRT25")
    
    };

}