using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
