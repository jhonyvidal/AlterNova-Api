namespace AlternovaBusiness.DTO;

public class AppointmentDTO
{
    public int Id { get; set; }
    public DateTime FechaHora { get; set; }
    public string Comment { get; set; }
    public int PatientId { get; set; }
    public string Doctor { get; set; }
    public string TypeAppointment { get; set; }

}