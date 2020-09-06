using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Mapping
{
    public class CommentMap : BaseMap<Comment>
    {
        public CommentMap()
        {
            ToTable("Comments");

            Property(x => x.Content).HasMaxLength(500).IsRequired();

            HasRequired(x => x.Owner)
                .WithMany(x => x.Comments)
                .HasForeignKey(x=>x.OwnerId)
                .WillCascadeOnDelete(false);

        }
    }
}
