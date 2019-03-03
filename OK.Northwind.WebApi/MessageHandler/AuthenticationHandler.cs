using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using OK.Northwind.Business.Abstract;
using OK.Northwind.Business.DependencyResolvers.Ninject;
using OK.NorthWind.Entities.Concrete;

namespace OK.Northwind.WebApi.MessageHandler
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();

                if (token != null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodedToken = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodedToken.Split(':');

                    IUserService userService = InstanceFactory.GetInstance<IUserService>();

                    User user = userService.GetUsernameAndPassword(tokenValues[0], tokenValues[1]);

                    if (user != null)
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), userService.GetUserRoles(user).Select(x=>x.UserRole).ToArray());
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch
            {

            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}