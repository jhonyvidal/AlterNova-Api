using System.ComponentModel.DataAnnotations;

namespace AlternovaData.Entities; 
public class TypeAppointment
{
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

}
