using AlternovaData.Entities;


namespace AlternovaBusiness.interfaces
{
    public interface IJwtHelper
    {
        public string GenerateJwtToken(User user);
    }
}
