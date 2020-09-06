using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Mapping
{
    public class RoleMap : BaseMap<Role>
    {
        public RoleMap()
        {
            ToTable("Roles");

            Property(x => x.Name).HasMaxLength(50).IsRequired();
            HasIndex(x => x.Name);
                
        }
    }
}
