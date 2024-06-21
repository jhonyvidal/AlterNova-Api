

using AlternovaBusiness.DTO;
using AlternovaBusiness.Models;
using AlternovaData.Entities;

namespace AlternovaBusiness.Interface;
public interface IAppointmentService {
    public IEnumerable<AppointmentDTO> Get(int id, int pageNumber, int pageSize);
    public Appointment Post(AppointmentRequest request,int id);
    public void Delete(int id);
}