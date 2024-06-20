using AlternovaBusiness.DTO;
using AlternovaBusiness.Interface;

namespace AlternovaBusiness.Services
{
    public class AppointmentServices : IAppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentServices(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> Get() => _context.Appointment.ToList();
        public Appointment Post(AppointmentDTO request)
        {
            var newAppointment = new Appointment
            {
                FechaHora = request.FechaHora,
                comment = request.Comment,
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                TypeAppointmentId = request.TypeAppointmentId,
            };
            try
            {
                _context.Appointment.Add(newAppointment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create Appointment.", ex);
            }
            return newAppointment;
        }

        public void Delete(int id)
        {
            var itemToRemove = _context.Appointment.FirstOrDefault(d => d.Id == id);
            if (itemToRemove != null)
            {
                _context.Appointment.Remove(itemToRemove);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Id not Found.");
            }
        }

    }
}
