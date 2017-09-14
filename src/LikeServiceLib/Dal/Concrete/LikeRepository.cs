using System;
using System.Collections.Generic;
using LikeService.Dal.Abstract;
using LikeService.Model;
using LiteDB;
using System.Linq;
using System.Linq.Expressions;

namespace LikeService.Dal.Concrete
{
    public sealed class LikeRepository : ILikeRepository
    {
        private readonly string connection;

        public LikeRepository(string connection)
        {
            this.connection = connection;
        }

        public void Create(Like Like)
        {
            using (var db = new LiteDatabase(connection))
            {
                var Likes = db.GetCollection<Like>();

                Likes.Insert(Like);
            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(connection))
            {
                var Likes = db.GetCollection<Like>();

                Likes.Delete(u => u.Id == id);
            }
        }

        public IEnumerable<Like> Filter(Expression<Func<Like, bool>> predicate)
        {
            using (var db = new LiteDatabase(connection))
            {
                var likes = db.GetCollection<Like>();

                return likes.Find(predicate).ToList();
            }
        }

        public Like Find(Expression<Func<Like, bool>> predicate)
        {
            using (var db = new LiteDatabase(connection))
            {
                var likes = db.GetCollection<Like>();

                return likes.FindOne(predicate);
            }
        }

        public Like Get(int id)
        {
            using (var db = new LiteDatabase(connection))
            {
                var Likes = db.GetCollection<Like>();

                return Likes.FindOne(u => u.Id == id);
            }
        }

        public void Update(Like Like)
        {
            using (var db = new LiteDatabase(connection))
            {
                var Likes = db.GetCollection<Like>();

                Likes.Update(Like);
            }
        }
    }
}
