namespace Tetra.Domain
{
    public class UserDomain
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string INN { get; set; }
        public UserDataDomain UserData { get; set; }
        public IEnumerable<RequestDomain> Requests { get; set; }
    }
}
