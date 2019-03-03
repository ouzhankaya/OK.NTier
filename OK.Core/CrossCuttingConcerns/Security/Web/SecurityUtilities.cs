using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace OK.Core.CrossCuttingConcerns.Security.Web
{
    public class SecurityUtilities
    {
        public Identity FormsAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            var identity = new Identity
            {
                Id = setId(ticket),
                Name = setName(ticket),
                Email = setEmail(ticket),
                FirstName = setFirstName(ticket),
                LastName = setLastName(ticket),
                Roles = setRoles(ticket),
                AuthenticationType = setAuthenticationType(),
                IsAuthenticated = setIsAuthecticated()
            };
            return identity;
        }

        private bool setIsAuthecticated()
        {
            return true;
        }

        private string setAuthenticationType()
        {
            return "Forms";
        }

        private string[] setRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            var roles = data[1].Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            return roles;  
        }

        private string setFirstName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }

        private string setLastName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[3];
        }

        private string setEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0];
        }

        private string setName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }

        private Guid setId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return new Guid(data[4]);
        }
    }
}
