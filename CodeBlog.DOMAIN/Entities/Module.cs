using CodeBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DOMAIN.Entities
{
    public class Module : BaseEntity
    {
        public string Name { get; set; }

        //Navigation Property
        //One

        //Many
        public List<Role> Roles { get; set; }
    }
}
