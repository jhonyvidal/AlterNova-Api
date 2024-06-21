using AlternovaBusiness.DTO;
using AlternovaData.Entities;

namespace AlternovaBusiness.Interface;
public interface IUserService {
    IEnumerable<UserDTO> Get();
    User Post(User request);
    string Login(string email, string password);
}