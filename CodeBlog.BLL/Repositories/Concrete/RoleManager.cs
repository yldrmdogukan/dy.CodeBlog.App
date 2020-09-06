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
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public EntityResult Delete(Role model)
        {
            try
            {
                if (_roleDal.Delete(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                return new EntityResult("Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<Role> Get(Expression<Func<Role, bool>> filter, params string[] includeList)
        {
            try
            {
                var Role = _roleDal.Get(filter, includeList);
                if (Role != null)
                    return new EntityResult<Role>(Role, "Başarılı", ResultState.Success);
                return new EntityResult<Role>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Role>(null, "Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<Role>> GetList(Expression<Func<Role, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var Roles = _roleDal.GetList(filter, includeList);
                if (Roles != null)
                    return new EntityResult<List<Role>>(Roles, "Başarılı", ResultState.Success);
                return new EntityResult<List<Role>>(null, "Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Role>>(null, "Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Insert(Role model)
        {
            try
            {
                if (_roleDal.Insert(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                return new EntityResult("Hata Oluştu ", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Update(Role model)
        {
            try
            {
                if (_roleDal.Update(model))
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
