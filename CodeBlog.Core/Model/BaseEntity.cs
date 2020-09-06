using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.Core.Model
{
    public abstract class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
            Created = DateTime.Now;
        }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
