using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.TweetsDto;

namespace TwitterClone.Application.Generics
{
    public class ApiResponse<TDto> where TDto : class
    {
        public bool Success { get; set; }
        public TDto? Data { get; set; }
    }

    public class Verify
    {
        public void Run()
        {
            var res = new ApiResponse<TweetDto>();

            res.Success = true;
            res.Data = new TweetDto()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Content = "Hello World"
            }; 

            
        }
    }
}
