using CodeBlog.BLL.Repositories.Abstract;
using CodeBlog.Core.Constants;
using CodeBlog.Core.Extentions;
using CodeBlog.Core.ResultTypes;
using CodeBlog.DAL.Abstract;
using CodeBlog.DAL.Concrete;
using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.BLL.Repositories.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public EntityResult Delete(Blog model)
        {
            try
            {
                if (_blogDal.Delete(model))
                    return new EntityResult("Silme başarılı", ResultState.Success);
                return new EntityResult("Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<Blog> Get(Expression<Func<Blog, bool>> filter, params string[] includeList)
        {
            try
            {
                Blog blog = _blogDal.Get(filter, includeList);
                if (blog != null)
                    return new EntityResult<Blog>(blog, "Başarılı", ResultState.Success);
                return new EntityResult<Blog>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Blog>(null, "Database Hatası", ResultState.Error);
            }
        }

        public EntityResult<List<Blog>> GetList(Expression<Func<Blog, bool>> filter = null, params string[] includeList)
        {
            try
            {
                List<Blog> blogs = _blogDal.GetList(filter, includeList);

                if (blogs != null)
                    return new EntityResult<List<Blog>>(blogs, "Başarılı", ResultState.Success);
                else
                    return new EntityResult<List<Blog>>(null, "Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Blog>>(null, "Database Hatasıı " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<Blog>> GetListByCountDescending(int count, Expression<Func<Blog, bool>> filter = null, params string[] includeList)
        {
            try
            {

                var blogs = _blogDal.GetListByCountDescending(count, filter, includeList);

                if (blogs != null)
                    return new EntityResult<List<Blog>>(blogs, "Başarılı", ResultState.Success);
                else
                    return new EntityResult<List<Blog>>(null, "Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Blog>>(null, "Database Hatası " + ex.ToInnestException(), ResultState.Error);
            }
        }

        public EntityResult Insert(Blog model)
        {
            try
            {
                if (_blogDal.Insert(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                else
                    return new EntityResult("Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Update(Blog model)
        {
            try
            {
                if (_blogDal.Update(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                else
                    return new EntityResult("Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }
    }
}
