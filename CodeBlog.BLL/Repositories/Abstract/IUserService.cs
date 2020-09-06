﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlog.DOMAIN.Entities;

namespace CodeBlog.BLL.Repositories.Abstract
{
    public interface IUserService : IGenericService<ApplicationUser>
    {
        ApplicationUser Login(string email, string password);
    }
}
