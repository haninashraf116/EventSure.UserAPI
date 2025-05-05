namespace EventSure.UserAPI.Models
{
    public class UserAccount
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string MembershipTier { get; set; } = "General";
    }
}
