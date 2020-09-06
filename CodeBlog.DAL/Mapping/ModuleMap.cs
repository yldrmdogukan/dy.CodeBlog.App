using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Mapping
{
    public class ModuleMap : BaseMap<Module>
    {
        public ModuleMap()
        {
            ToTable("Modules");

            Property(x => x.Name).HasMaxLength(30).IsRequired();
            HasIndex(x => x.Name).IsUnique();

            HasMany(x => x.Roles)
                .WithMany(x => x.Modules)
                .Map(x => x.MapLeftKey("Roles").MapRightKey("Modules").ToTable("RolesModules"));
                
                
        }
    }
}
