namespace TwitterClone.Application.Dtos
{
    public class FollowDto
    {
        public Guid Id { get; set; }
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
    }
}