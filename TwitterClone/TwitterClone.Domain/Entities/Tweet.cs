namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity
    {
        public string Content { get; set; }
    
        public Tweet(string content) : base(Guid.NewGuid()) // constructor chaining
        {
            Content = content; // required field
        }
    }
}
