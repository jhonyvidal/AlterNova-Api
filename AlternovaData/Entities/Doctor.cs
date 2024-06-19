
using System.ComponentModel.DataAnnotations;

namespace AlternovaData.Entities; 
public class Doctor
{
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Speciality { get; set; }
        
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
