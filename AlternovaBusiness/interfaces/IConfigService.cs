

using AlternovaBusiness.DTO;

namespace AlternovaBusiness.Interface;
public interface IConfigService {
    public IEnumerable<DoctorDTO> GetDoctor();
    public IEnumerable<TypeDTO> GetType();

}