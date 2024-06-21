

using AlternovaBusiness.DTO;
using AlternovaData.Entities;

namespace AlternovaBusiness.Interface;
public interface IConfigService {
    public IEnumerable<DoctorDTO> GetDoctor();
    public IEnumerable<TypeDTO> GetType();

}