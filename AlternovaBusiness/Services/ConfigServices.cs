using AlternovaBusiness.DTO;
using AlternovaBusiness.Interface;
using AlternovaData.Entities;

namespace AlternovaBusiness.Services
{
    public class ConfigServices : IConfigService
    {
        private readonly AppDbContext _context;

        public ConfigServices(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetDoctor() => _context.Doctor.ToList();
        public IEnumerable<TypeAppointment> GetType() => _context.TypeAppointment.ToList();

    }
}
