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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public EntityResult Delete(Category model)
        {
            try
            {
                if (_categoryDal.Delete(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                else
                    return new EntityResult("Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<Category> Get(Expression<Func<Category, bool>> filter, params string[] includeList)
        {
            try
            {
                var category = _categoryDal.Get(filter, includeList);
                if (category != null)
                    return new EntityResult<Category>(category, "Başarılı", ResultState.Success);
                return new EntityResult<Category>(null, "Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Category>(null, "Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<Category>> GetList(Expression<Func<Category, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var categories = _categoryDal.GetList(filter, includeList);
                if (categories != null)
                    return new EntityResult<List<Category>>(categories, "Başarılı", ResultState.Success);
                return new EntityResult<List<Category>>(null, "Hata Oluştu", ResultState.Warning);
                
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Category>>(null, "Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Insert(Category model)
        {
            try
            {
                if (_categoryDal.Insert(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                return new EntityResult("Hatalı", ResultState.Error);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database Hatası " + ex.ToInnestException(), ResultState.Success);
            }
        }

        public EntityResult Update(Category model)
        {
            try
            {
                if (_categoryDal.Update(model))
                    return new EntityResult("Ekleme işlemi Başarılı", ResultState.Success);
                return new EntityResult("Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database Hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }


        }
    }
}
