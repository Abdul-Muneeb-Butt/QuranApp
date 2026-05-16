using Microsoft.EntityFrameworkCore;
using QuranApp.Models;

namespace QuranApp.Services
{
    public class AuthService
    {
        private readonly IDbContextFactory<AppDbContext> _dbFactory;

        public AuthService(IDbContextFactory<AppDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<bool> RegisterAsync(string fullName,
            string email, string password)
        {
            using var db = _dbFactory.CreateDbContext();

            var exists = await db.Users
                .AnyAsync(u => u.Email == email);
            if (exists) return false;

            var user = new User
            {
                FullName = fullName,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<User?> LoginAsync(string email,
            string password)
        {
            using var db = _dbFactory.CreateDbContext();

            var user = await db.Users
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            bool valid = BCrypt.Net.BCrypt
                .Verify(password, user.Password);
            return valid ? user : null;
        }
    }
}