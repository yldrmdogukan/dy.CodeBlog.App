

using CodeBlog.Core.ResultTypes;
using CodeBlog.DOMAIN.Entities;

namespace CodeBlog.BLL.Repositories.Abstract
{
    public interface IModuleService : IGenericService<Module>
    {
        EntityResult<Module> GetByRoleName(string name, params string[] includeList);
    }
}
