using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Mapping
{
    public class SocialMap : BaseMap<Social>
    {
        public SocialMap()
        {
            ToTable("Socials");

            Property(x => x.Url).HasMaxLength(150).IsRequired();
        }
    }
}
