using System.ComponentModel.DataAnnotations;

namespace AlternovaData.Entities;
public class User
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Name { get; set; }

    [Required, MaxLength(150)]
    public string LastName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; } 
    public string Role { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
