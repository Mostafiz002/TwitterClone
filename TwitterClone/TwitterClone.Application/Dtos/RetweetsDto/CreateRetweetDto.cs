using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos.RetweetsDto
{
    public class CreateRetweetDto
    {
        public required Guid UserId { get; set; }
        public required Guid TweetId { get; set; }
    }
}
