namespace TwitterClone.Domain.Entities

{
    public class User : BaseEntity
    {
        public User(string email) : base(Guid.NewGuid())
        {
            Email = email;
        }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Email { get; set; }
    }
}
