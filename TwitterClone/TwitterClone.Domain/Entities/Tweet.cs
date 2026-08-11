namespace TwitterClone.Domain.Entities
{
    public class Tweet
    {
        public Guid Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public string Content { get; set; }
        
        public Tweet()
        {
            Id = Guid.NewGuid();
            AuthorId = Guid.NewGuid();
        }
    }
}
