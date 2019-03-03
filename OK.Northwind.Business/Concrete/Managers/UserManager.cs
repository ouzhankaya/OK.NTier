using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OK.Northwind.Business.Abstract;
using OK.Northwind.DataAccess.Abstract;
using OK.NorthWind.Entities.ComplexTypes;
using OK.NorthWind.Entities.Concrete;

namespace OK.Northwind.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetUsernameAndPassword(string username, string password)
        {
            return _userDal.Get(u => u.Username == username & u.Password == password);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
