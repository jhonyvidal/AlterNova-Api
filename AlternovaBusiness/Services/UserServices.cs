using AlternovaBusiness.Helper;
using AlternovaBusiness.Interface;
using AlternovaBusiness.interfaces;
using AlternovaData.Entities;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlternovaBusiness.Services
{
    public class UserService : IUserService
    {

        private readonly AppDbContext _context;
        private readonly IJwtHelper _jwtService;
        public UserService(AppDbContext context, IJwtHelper jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }
        public IEnumerable<User> Get() => _context.User.ToList();


        public User Post(User request)
        {
            if (_context.User.Any(u => u.Email == request.Email))
            {
                throw new Exception("Email address is already registered.");
            }
            try
            {
                request.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);
                _context.User.Add(request);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create user.", ex);
            }
            return request;
        }
        public string Login(string email, string password)
        {
            var user = _context.User.FirstOrDefault(x => x.Email == email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            return _jwtService.GenerateJwtToken(user);
        }


    }
}
