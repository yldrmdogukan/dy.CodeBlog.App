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
    public class ModuleManager : IModuleService
    {
        private readonly IModuleDal _moduleDal;

        public ModuleManager(IModuleDal moduleDal)
        {
            _moduleDal = moduleDal;
        }

        public EntityResult Delete(Module model)
        {
            try
            {
                if (_moduleDal.Delete(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                return new EntityResult("Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<Module> Get(Expression<Func<Module, bool>> filter, params string[] includeList)
        {
            try
            {
                var module = _moduleDal.Get(filter, includeList);
                if (module != null)
                    return new EntityResult<Module>(module, "Başarılı", ResultState.Success);
                return new EntityResult<Module>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Module>(null, "Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<Module> GetByRoleName(string name, params string[] includeList)
        {
            try
            {
                var module = _moduleDal.Get(x => x.Name == name,includeList);
                if (module != null)
                    return new EntityResult<Module>(module, "Başarılı", ResultState.Success);
                return new EntityResult<Module>(null, "Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Module>(null, "Database Hatası "+ex.ToInnestException(), ResultState.Error);
            }
        }

        public EntityResult<List<Module>> GetList(Expression<Func<Module, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var Modules = _moduleDal.GetList(filter, includeList);
                if (Modules != null)
                    return new EntityResult<List<Module>>(Modules, "Başarılı", ResultState.Success);
                return new EntityResult<List<Module>>(null, "Hata Oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Module>>(null, "Database Hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Insert(Module model)
        {
            try
            {
                if (_moduleDal.Insert(model))
                    return new EntityResult("Başarılı", ResultState.Success);
                return new EntityResult("Hata Oluştu ", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult("Database hatası " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Update(Module model)
        {
            try
            {
                if (_moduleDal.Update(model))
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
