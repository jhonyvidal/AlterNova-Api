using System.ComponentModel.DataAnnotations;

namespace AlternovaBusiness.DTO;

public class AppointmentDTO
{
    [Key]
    public int Id { get; set; }
    
    public DateTime FechaHora { get; set; }
    public string Comment { get; set; }
    
    [Required]
    public int PatientId { get; set; }

    [Required]
    public int DoctorId { get; set; }

    [Required]
    public int TypeAppointmentId { get; set; }
}