using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lagosanto.Models;

[Table("Users")]
public class User
{
    [Column("Id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("Username"), MaxLength(50)]
    public string Username { get; set; }

    [MaxLength(50)]
    public string Password { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(50)]
    public string Role { get; set; }
}