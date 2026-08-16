namespace TwitterClone.Domain.Entities
{
    public abstract class Notification : BaseEntity
    {
        private Guid UserId { get; set; }
        protected string Message { get; set; }
        protected string Type { get; set; }
        private bool IsRead{ get; set; }

        public Notification(string notificatinType) : base(Guid.NewGuid())
        {
            Type = notificatinType;
        }

        public abstract string GetMessage(); // mendatory method to be implemented by clild classes // abstruction
    }
}
