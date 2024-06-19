using AlternovaBusiness.Interface;
using AlternovaData.Entities;

namespace AlternovaBusiness.Services
{
    public class UserService : IUserService
    {

        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> Get() => _context.User.ToList();

        public User Post(User request)
        {
            _context.User.Add(request);
            _context.SaveChanges();
            return request;
        }

    }
}
