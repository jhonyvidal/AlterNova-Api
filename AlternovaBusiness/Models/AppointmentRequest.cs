using System.ComponentModel.DataAnnotations;

namespace AlternovaBusiness.Models
{
    public class AppointmentRequest
    {
        [Key]
        public int Id { get; set; }

        public DateTime FechaHora { get; set; }
        public string Comment { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int TypeAppointmentId { get; set; }
    }
}
