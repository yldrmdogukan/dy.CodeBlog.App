using CodeBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DOMAIN.Entities
{
    public class Ticket : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public TicketStatus Status { get; set; }

        //Navigation Property
        //One
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        //Many
        public List<TicketResponse> Responses { get; set; }
    }
}
