using CodeBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Mapping
{
    public class BaseMap<T>: EntityTypeConfiguration<T> where T:BaseEntity
    {
        public BaseMap()
        {
            Property(x => x.Created).HasColumnType("datetime2");
            //Todo : Property(x => x.Updated).HasColumnType("datetime2");
            HasKey(x => x.Id);
        }
    }
}
