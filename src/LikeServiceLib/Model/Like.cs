namespace LikeService.Model
{
    public sealed class Like
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public long Likes { get; set; }
    }
}
