using CodeBlog.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DOMAIN.Entities
{
    public class Social : BaseEntity
    {
        public SocialType Type { get; set; }
        public string Url { get; set; }

        //Navigation Property
        //One
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        //Many
    }
}
