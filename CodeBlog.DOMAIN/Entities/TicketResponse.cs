using CodeBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DOMAIN.Entities
{
    public class TicketResponse : BaseEntity
    {
        public string Content { get; set; }

        //Navigation Property
        //One
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        //Many

    }
}
