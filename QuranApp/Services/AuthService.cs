using Microsoft.EntityFrameworkCore;
using QuranApp.Models;

namespace QuranApp.Services
{
    public class AuthService
    {
        private readonly AppDbContext _db;

        public AuthService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> RegisterAsync(string fullName,
            string email, string password)
        {
            var exists = await _db.Users
                .AnyAsync(u => u.Email == email);
            if (exists) return false;

            var user = new User
            {
                FullName = fullName,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<User?> LoginAsync(string email,
            string password)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            bool valid = BCrypt.Net.BCrypt
                .Verify(password, user.Password);
            return valid ? user : null;
        }
    }
}