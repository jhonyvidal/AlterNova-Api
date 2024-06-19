using Appointment.Business.DTO;

namespace Appointment.Core.Interface;
public interface IAppointmentService {
    Task<List<AppointmentDTO>> GetCarDetailsAsync();
    bool IsDatabaseConnected();
}