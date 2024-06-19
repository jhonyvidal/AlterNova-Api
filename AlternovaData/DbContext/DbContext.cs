
using Microsoft.EntityFrameworkCore;
using AlternovaData.Entities;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Appointment> Appointment { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<TypeAppointment> TypeAppointment { get; set; }
    public DbSet<Doctor> Doctor { get; set; }

}