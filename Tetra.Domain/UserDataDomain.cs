namespace Tetra.Domain
{
    public class UserDataDomain
    {
        public Guid Id { get; set; }
        public string PasswordHash { get; set; }
        public Guid UserId { get; set; }
        public UserDomain User { get; set; }
    }
}
