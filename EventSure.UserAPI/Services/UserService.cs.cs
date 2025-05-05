using EventSure.UserAPI.Models;
using BCrypt.Net;

namespace EventSure.UserAPI.Services
{
    public class UserService
    {
        private static List<UserAccount> _users = new();

        public bool Register(UserAccount user, string password)
        {
            if (_users.Any(u => u.Email == user.Email)) return false;

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            if (string.IsNullOrEmpty(user.MembershipTier))
                user.MembershipTier = "General";

            _users.Add(user);
            return true;
        }

        public bool Login(string email, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == email);
            if (user == null) return false;

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
    }
}

