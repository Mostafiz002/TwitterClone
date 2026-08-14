using TwitterClone.Domain.Entities;

var likeNotification = new LikeNotification(Guid.NewGuid());

Console.WriteLine(likeNotification.DescribeRecords());