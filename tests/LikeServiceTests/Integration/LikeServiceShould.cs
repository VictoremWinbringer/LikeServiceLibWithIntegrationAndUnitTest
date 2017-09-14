using LikeService.Dal.Abstract;
using LikeService.Dal.Concrete;
using LikeService.Model;
using LikeService.Services.Abstract;
using Xunit;

namespace LikeServiceTests
{
    public class LikeServiceShould
    {
        private readonly ILikeRepository repository;
        private readonly ILikeService service;

        public LikeServiceShould()
        {
            repository = new LikeRepository("Test.db");
            service = new LikeService.Services.Concrete.LikeService(repository);
        }

        [Fact]
        public void LikePlayerAndGetLikes()
        {
            var playerId = "1";

            var oldLikes = service.GetLikes(playerId);

            service.Like(playerId);

            var newLikes = service.GetLikes(playerId);

            Assert.Equal(oldLikes, newLikes - 1);
        }
    }
}
