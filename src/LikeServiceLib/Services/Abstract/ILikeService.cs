namespace LikeService.Services.Abstract
{
    public interface ILikeService
    {
        void Like(string playerId);
        long GetLikes(string playerId);
    }
}
