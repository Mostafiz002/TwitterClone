using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos.RetweetsDto
{
    public class RetweetDto
    {
        public required string Id { get; set; }
        public required string UserId { get; set; }
        public required string TweetId { get; set; }
        public required DateTime RetweetedAt { get; set; }
    }
}
