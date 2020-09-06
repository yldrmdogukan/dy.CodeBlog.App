using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Mapping
{
    public class UserMap : BaseMap<ApplicationUser>
    {
        public UserMap()
        {
            ToTable("Users");
            Property(x => x.FullName).IsRequired().HasMaxLength(50);
            Property(x => x.Password).IsRequired().HasMaxLength(15);
            Property(x => x.Email).HasColumnType("nvarchar").HasMaxLength(50);
            HasIndex(x => x.Email).IsUnique();
            Property(x => x.LastLogin).HasColumnType("datetime2");

            HasMany(x => x.Blogs)
                .WithRequired(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Comments)
                .WithRequired(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Socials)
                .WithRequired(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Tickets)
                .WithRequired(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.TicketResponses)
                .WithRequired(x => x.Owner)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .WillCascadeOnDelete(false);




        }
    }
}
