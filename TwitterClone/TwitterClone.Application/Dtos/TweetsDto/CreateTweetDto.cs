using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos.TweetsDto
{
    public class CreateTweetDto
    {
        public required string Content { get; set; }
        public required Guid UserId { get; set; }
    }
}
