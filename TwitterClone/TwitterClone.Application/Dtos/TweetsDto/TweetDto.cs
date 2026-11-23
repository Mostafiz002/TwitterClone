using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos.TweetsDto
{
    public class TweetDto
    {
        public required Guid Id { get; set; }
        public required string Content { get; set; }
        public required Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
