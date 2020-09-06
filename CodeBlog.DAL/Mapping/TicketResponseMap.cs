using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Mapping
{
    public class TicketResponseMap : BaseMap<TicketResponse>
    {
        public TicketResponseMap()
        {
            ToTable("TicketResponses");

            Property(x => x.Content).HasMaxLength(500).IsRequired();

        }
    }
}
