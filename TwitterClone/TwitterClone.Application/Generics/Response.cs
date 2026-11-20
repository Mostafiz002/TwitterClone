using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.TweetsDto;

namespace TwitterClone.Application.Generics
{
    public class Response
    {
        public bool Success { get; set; }
        public object? Data { get; set; }
    }
    public class Test
    {
        public void Run()
        {
            var res = new Response();

            res.Success = true;
            res.Data = new TweetDto()
            { 
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Content = "Hello World"
            }; // upcasting...

            var tweet = (TweetDto)res.Data;  // downcasting...
        }
    }
}
