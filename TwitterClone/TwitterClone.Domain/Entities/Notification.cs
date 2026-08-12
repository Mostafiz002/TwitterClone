namespace TwitterClone.Domain.Entities
{
    class Notification : BaseEntity
    {
        public string Content { get; set; }
        public string Type { get; set; }
        public bool IsRead{ get; set; }

        public Notification(string type) : base(Guid.NewGuid())
        {
            Type = type;
        }
    }
}
