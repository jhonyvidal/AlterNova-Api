

using System.ComponentModel.DataAnnotations;

namespace AlternovaData.Entities; 
public class Appointment
{
    [Key]
    public int Id { get; set; }
    
    public DateTime FechaHora { get; set; }
    public string comment { get; set; }
    
    [Required]
    public int PatientId { get; set; }
    public User Patient { get; set; }

    [Required]
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    [Required]
    public int TypeAppointmentId { get; set; }
    public TypeAppointment TypeAppointment { get; set; }
}