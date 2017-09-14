using LikeService.Dal.Abstract;
using LikeService.Model;
using LikeService.Services.Abstract;
using System;

namespace LikeService.Services.Concrete
{
    public sealed class LikeService : ILikeService
    {
        private readonly ILikeRepository repository;

        public LikeService(ILikeRepository repository)
        {
            this.repository = repository;
        }

        public long GetLikes(string playerId)
        {
            if (string.IsNullOrWhiteSpace(playerId))
               throw new ArgumentNullException(nameof(playerId));

            return repository.Find(l =>
            l.UserId.Equals(playerId, StringComparison.Ordinal))?.Likes ?? 0;
        }

        public void Like(string playerId)
        {
            if (string.IsNullOrWhiteSpace(playerId))
                throw new ArgumentNullException(nameof(playerId));

            var like = repository.Find(l =>
             l.UserId.Equals(playerId, StringComparison.Ordinal));

            if (like == null)
            {
                repository.Create(new Like
                {
                    Likes = 1,
                    UserId = playerId
                });
            }
            else
            {
                like.Likes += 1;

                repository.Update(like);
            }
        }
    }
}
