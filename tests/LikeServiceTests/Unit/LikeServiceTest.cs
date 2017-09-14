using LikeService.Dal.Abstract;
using LikeService.Model;
using LikeService.Services.Abstract;
using Moq;
using System;
using System.Linq.Expressions;
using Xunit;

namespace LikeServiceTests.Unit
{
    public class LikeServiceTest
    {
        private readonly Mock<ILikeRepository> repository;
        private readonly ILikeService service;
        public LikeServiceTest()
        {
            repository = new Mock<ILikeRepository>();

            service = new LikeService.Services.Concrete.LikeService(repository.Object);


        }
        [Fact]
        public void LikeTest()
        {
            var like = new Like
            {
                Id = 1,
                Likes = 1
            };

            repository.Setup(r => r.Find(It.IsAny<Expression<Func<Like, bool>>>()))
                .Returns(like);

            service.Like("1");

            repository.Verify(r => r.Find(It.IsAny<Expression<Func<Like, bool>>>()));

            repository.Verify(r => r.Update(like));

            Assert.Equal(2, like.Likes);
        }

        [Fact]
        public void GetLikesTest()
        {
            var like = new Like
            {
                Id = 1,
                Likes = 8
            };

            repository.Setup(r => r.Find(It.IsAny<Expression<Func<Like, bool>>>()))
                .Returns(like);

            var result = service.GetLikes("1");

            Assert.Equal(8, result);
        }
    }
}
