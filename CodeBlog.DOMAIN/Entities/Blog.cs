using CodeBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DOMAIN.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string PosterPath { get; set; }
        public int Likes { get; set; }
        public int Views { get; set; }

        //Navigation Property
        //One
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //Many
        public List<Comment> Comments { get; set; }
    }
}
