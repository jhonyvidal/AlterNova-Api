using AlternovaBusiness.DTO;
using AlternovaBusiness.Interface;
using AlternovaBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace AlternovaBusiness.Services
{
    public class AppointmentServices : IAppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentServices(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AppointmentDTO> Get(int id, int pageNumber, int pageSize)
        {
            return _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.TypeAppointment)
                .Where(a => a.PatientId == id)
                .OrderBy(a => a.Id) 
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new AppointmentDTO
                {
                    Id = a.Id,
                    FechaHora = a.FechaHora,
                    Comment = a.comment,
                    Doctor = a.Doctor.Name,
                    TypeAppointment = a.TypeAppointment.Name,
                    PatientId = a.PatientId,
                })
                .ToList();
        }
        public Appointment Post(AppointmentRequest request, int i)
        {
            var newAppointment = new Appointment
            {
                FechaHora = request.FechaHora,
                comment = request.Comment,
                PatientId = i,
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
