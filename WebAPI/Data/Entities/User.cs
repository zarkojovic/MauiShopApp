
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAPI.Constants;

namespace WebAPI.Data.Entities;
[Table(nameof(User))]
public class User
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    [Required, MaxLength(100)]
    public string Email { get; set; }
    [Required, MaxLength(20)]
    public string Mobile { get; set; }
    public short RoleId { get; set; }
    [Required, MaxLength(25)]
    public string Password { get; set; }
    public virtual Role Role { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }

    public static IEnumerable<User> GetInitalUsers() => new List<User>
    {
        new User
        {
            Id = 1,
            Name = "Zarko Jovic",
            Email = "zarkojovic1302@gmail.com",
            Password = "12345678",
            Mobile = "1234567890",
            RoleId = DatabaseConstants.Roles.Admin.Id
        }
    };
}