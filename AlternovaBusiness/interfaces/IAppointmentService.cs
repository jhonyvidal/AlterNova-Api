

using AlternovaBusiness.DTO;
using AlternovaData.Entities;

namespace AlternovaBusiness.Interface;
public interface IAppointmentService {
    public IEnumerable<Appointment> Get();
    public Appointment Post(AppointmentDTO request);
    public void Delete(int id);
}