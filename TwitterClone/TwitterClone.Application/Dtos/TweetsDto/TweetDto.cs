using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos.TweetsDto
{
    public class TweetDto
    {
        public required string Id { get; set; }
        public required string Content { get; set; }
        public required string UserId { get; set; }
    }
}
