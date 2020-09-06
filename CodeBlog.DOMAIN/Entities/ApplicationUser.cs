using CodeBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DOMAIN.Entities
{
    public class ApplicationUser : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public string ProfilePicturePath { get; set; }
        public string AboutText { get; set; }

        //Navigation Property
        //One
        public int RoleId { get; set; }
        public Role Role { get; set; }
        //Many
        public List<Blog> Blogs { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Social> Socials { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<TicketResponse> TicketResponses { get; set; }

    }
}
