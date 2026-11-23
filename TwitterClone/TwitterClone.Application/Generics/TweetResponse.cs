using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.TweetsDto;

namespace TwitterClone.Application.Generics
{
    public class TweetResponse
    {
        public bool Success { get; set; }
        public TweetDto? Tweet { get; set; }
    }
}
