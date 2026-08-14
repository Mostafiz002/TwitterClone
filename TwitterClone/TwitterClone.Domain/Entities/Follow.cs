namespace TwitterClone.Domain.Entities
{
    public class Follow : BaseEntity
    {
        public Guid FollowerId { get; }
        public Guid FollowingId { get; }

        public Follow(Guid followerId, Guid followingId) : base(Guid.NewGuid())
        {
            FollowerId = followerId;
            FollowingId = followingId;
        }
    }
}
