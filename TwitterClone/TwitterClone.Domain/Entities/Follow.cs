namespace TwitterClone.Domain.Entities
{
    public class Follow
    {
        public Guid Id { get; private set; }
        public Guid FollowerId { get; }
        public Guid FollowingId { get; }
        public DateTime FollowedAt { get; }

        public Follow(Guid followerId, Guid followingId)
        {
            Id = Guid.NewGuid();
            FollowerId = followerId;
            FollowingId = followingId;
            FollowedAt = DateTime.UtcNow;
        }
    }
}
