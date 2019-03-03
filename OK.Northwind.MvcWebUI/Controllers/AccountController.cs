using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OK.Core.CrossCuttingConcerns.Security.Web;
using OK.Northwind.Business.Abstract;

namespace OK.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public String Login(string userName, string password)
        {
            var user = _userService.GetUsernameAndPassword(userName, password);
            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(),
                    user.Username,
                    user.Email,
                    DateTime.Now.AddDays(15),
                    _userService.GetUserRoles(user).Select(x=>x.UserRole).ToArray(),
                    false,
                    user.FirstName,
                    user.LastName
                );
                return "user is authenticated";
            }

            return "user is not authenticated";

        }
    }
}