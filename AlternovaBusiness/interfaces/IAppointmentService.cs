

using AlternovaBusiness.DTO;
using AlternovaBusiness.Dtos;
using AlternovaBusiness.Models;

namespace AlternovaBusiness.Interface;
public interface IAppointmentService {
    public PaginationResult<AppointmentDTO> Get(int id, int pageNumber, int pageSize);
    public Appointment Post(AppointmentRequest request,int id);
    public void Delete(int id);
}