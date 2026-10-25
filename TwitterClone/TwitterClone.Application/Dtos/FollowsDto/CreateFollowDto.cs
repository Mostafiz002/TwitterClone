namespace TwitterClone.Application.Dtos
{
    public class CreateFollowDto
    {
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
    }
}