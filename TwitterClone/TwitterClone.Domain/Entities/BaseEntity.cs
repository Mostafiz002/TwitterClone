namespace TwitterClone.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime? ModifiedAt { get; }
        public Guid CreatedBy { get; private set; }
        public Guid? ModifiedBy { get; private set; }

        public BaseEntity(Guid id)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
        }

        public virtual string DescribeRecords()
        {
            return $"Id: {Id}, CreatedAt: {CreatedAt}, ModifiedAt: {ModifiedAt}, CreatedBy: {CreatedBy}, ModifiedBy: {ModifiedBy}";
        }
    }
}
