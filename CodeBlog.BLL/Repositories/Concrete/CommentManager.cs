using CodeBlog.BLL.Repositories.Abstract;
using CodeBlog.Core.Constants;
using CodeBlog.Core.Extentions;
using CodeBlog.Core.ResultTypes;
using CodeBlog.DAL.Abstract;
using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.BLL.Repositories.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public EntityResult Delete(Comment model)
        {
            try
            {
                if (_commentDal.Delete(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                return new EntityResult("Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<Comment> Get(Expression<Func<Comment, bool>> filter, params string[] includeList)
        {
            try
            {
                var comment = _commentDal.Get(filter, includeList);
                if (comment != null)
                    return new EntityResult<Comment>(comment, "Başarılı", ResultState.Success);
                return new EntityResult<Comment>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Comment>(null, "Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<Comment>> GetList(Expression<Func<Comment, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var comments = _commentDal.GetList(filter, includeList);
                if (comments != null)
                    return new EntityResult<List<Comment>>(comments, "Başarılı", ResultState.Success);
                return new EntityResult<List<Comment>>(null, "Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Comment>>(null, "Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Insert(Comment model)
        {
            try
            {
                if (_commentDal.Insert(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                return new EntityResult("Hata Oluştu ", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Update(Comment model)
        {
            try
            {
                if (_commentDal.Update(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                return new EntityResult("Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("DataBase Hatası", ResultState.Error);
            }
        }
    }
}
