using LikeService.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LikeService.Dal.Abstract
{
    public interface ILikeRepository
    {
        IEnumerable<Like> Filter(Expression<Func<Like, bool>> predicate);
        Like Find(Expression<Func<Like, bool>> predicate);
        Like Get(int id);
        void Create(Like user);
        void Update(Like user);
        void Delete(int id);
    }
}
