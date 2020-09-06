using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Mapping
{
    public class BlogMap : BaseMap<Blog>
    {
        public BlogMap()
        {
            ToTable("Blogs");
            Property(x => x.Title).HasMaxLength(150).IsRequired();
            Property(x => x.Description).HasMaxLength(500).IsRequired();
            Property(x => x.Content).IsRequired();
            Property(x => x.PosterPath).IsRequired();

            HasMany(x => x.Comments)
                .WithRequired(x => x.Blog)
                .HasForeignKey(x=>x.OwnerId)
                .WillCascadeOnDelete(false);
            
            HasRequired(x => x.Category)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
