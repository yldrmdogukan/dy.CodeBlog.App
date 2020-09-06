using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Mapping
{
    public class TicketMap : BaseMap<Ticket>
    {
        public TicketMap()
        {
            ToTable("Titles");

            Property(x => x.Title).HasMaxLength(50).IsRequired();
            Property(x => x.Content).HasMaxLength(500).IsRequired();

            HasMany(x => x.Responses)
                .WithRequired(x => x.Ticket)
                .HasForeignKey(x => x.TicketId)
                .WillCascadeOnDelete(false);
        }
    }
}
