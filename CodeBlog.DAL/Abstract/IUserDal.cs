using CodeBlog.Core.Data.EF;
using CodeBlog.DOMAIN.Entities;

namespace CodeBlog.DAL.Abstract
{
    public interface IUserDal : IRepository<ApplicationUser>
    {
    }
}
