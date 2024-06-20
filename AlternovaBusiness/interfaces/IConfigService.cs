

using AlternovaBusiness.DTO;
using AlternovaData.Entities;

namespace AlternovaBusiness.Interface;
public interface IConfigService {
    public IEnumerable<Doctor> GetDoctor();
    public IEnumerable<TypeAppointment> GetType();

}