using CodeBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DOMAIN.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public int Likes { get; set; }

        //Navigation Property
        //One
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        //Many
    }
}
