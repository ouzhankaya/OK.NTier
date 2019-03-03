using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OK.NorthWind.Entities.ComplexTypes;
using OK.NorthWind.Entities.Concrete;

namespace OK.Northwind.Business.Abstract
{
    public interface IUserService
    {
        User GetUsernameAndPassword(string username, string password);
        List<UserRoleItem> GetUserRoles(User user);
    }
}
