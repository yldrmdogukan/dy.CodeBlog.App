using CodeBlog.Core.Data.EF;
using CodeBlog.DAL.Abstract;
using CodeBlog.DAL.Context;
using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Concrete
{
    public class TicketDal : Repository<Ticket, CodeBlogDbContext>, ITicketDal
    {
        public TicketDal(CodeBlogDbContext context) : base(context)
        {
        }
    }
}
