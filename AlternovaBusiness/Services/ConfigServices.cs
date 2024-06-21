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

        public IEnumerable<DoctorDTO> GetDoctor() => _context.Doctor.Select(a => new DoctorDTO
        {
            Id = a.Id,
            Name = a.Name,
        })
        .ToList();
        public IEnumerable<TypeDTO> GetType() => _context.TypeAppointment.Select(a => new TypeDTO
        {
            Id = a.Id,
            Name = a.Name,
        })
        .ToList();

    }
}
