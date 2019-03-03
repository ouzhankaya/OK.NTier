using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OK.Core.DataAccess.EntityFramework;
using OK.Northwind.DataAccess.Abstract;
using OK.NorthWind.Entities.ComplexTypes;
using OK.NorthWind.Entities.Concrete;

namespace OK.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EFEntityRepositoryBase<User, NorthWindContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (NorthWindContext context = new NorthWindContext())
            {
                var result = from ur in context.UserRoles
                    join r in context.Roles on ur.UserId equals user.Id
                    where ur.UserId == user.Id
                    select new UserRoleItem {UserRole = r.Name};

                return result.ToList();
            }
        }
    }
}
