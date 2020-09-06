using CodeBlog.Core.Data.EF;
using CodeBlog.DAL.Abstract;
using CodeBlog.DAL.Context;
using CodeBlog.DOMAIN.Entities;

namespace CodeBlog.DAL.Concrete
{
    public class RoleDal : Repository<Role, CodeBlogDbContext>, IRoleDal
    {
        public RoleDal(CodeBlogDbContext context) : base(context)
        {
        }
    }
}
