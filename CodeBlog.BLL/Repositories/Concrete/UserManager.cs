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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public EntityResult Delete(ApplicationUser model)
        {
            try
            {
                if (_userDal.Delete(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                return new EntityResult("Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<ApplicationUser> Get(Expression<Func<ApplicationUser, bool>> filter, params string[] includeList)
        {
            try
            {
                var user = _userDal.Get(filter, includeList);
                if (user != null)
                    return new EntityResult<ApplicationUser>(user, "Başarılı", ResultState.Success);
                return new EntityResult<ApplicationUser>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<ApplicationUser>(null, "Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<ApplicationUser>> GetList(Expression<Func<ApplicationUser, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var Users = _userDal.GetList(filter, includeList);
                if (Users != null)
                    return new EntityResult<List<ApplicationUser>>(Users, "Başarılı", ResultState.Success);
                return new EntityResult<List<ApplicationUser>>(null, "Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<ApplicationUser>>(null, "Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Insert(ApplicationUser model)
        {
            try
            {
                if (_userDal.Insert(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                return new EntityResult("Hata Oluştu ", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public ApplicationUser Login(string email, string password)
        {
            var user = _userDal.Get(x => x.Email == email & x.Password == password);
            user.LastLogin = DateTime.Now;
            _userDal.Update(user);
            return user;
        }

        public EntityResult Update(ApplicationUser model)
        {
            try
            {
                if (_userDal.Update(model))
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
