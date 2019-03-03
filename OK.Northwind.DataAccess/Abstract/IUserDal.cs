﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OK.Core.DataAccess;
using OK.NorthWind.Entities.ComplexTypes;
using OK.NorthWind.Entities.Concrete;

namespace OK.Northwind.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<UserRoleItem> GetUserRoles(User user);
    }
}
