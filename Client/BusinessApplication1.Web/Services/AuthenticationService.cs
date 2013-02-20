namespace BusinessApplication1.Web
{
    using System.Security.Authentication;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.ServiceModel.DomainServices.Server.ApplicationServices;
    using System.Threading;

    using System.Collections.Generic;
    using System.Security.Principal;

    // TODO: Switch to a secure endpoint when deploying the application.
    //       The user's name and password should only be passed using https.
    //       To do this, set the RequiresSecureEndpoint property on EnableClientAccessAttribute to true.
    //   
    //       [EnableClientAccess(RequiresSecureEndpoint = true)]
    //
    //       More information on using https with a Domain Service can be found on MSDN.

    /// <summary>
    /// Domain Service responsible for authenticating users when they log on to the application.
    ///
    /// Most of the functionality is already provided by the AuthenticationBase class.
    /// </summary>
    [EnableClientAccess]
    public class AuthenticationService : AuthenticationBase<User> {
        protected override bool ValidateUser(string username, string password)
        {
            //using (var db = DataService.GetSession())
            //{
                //return db.GetFirst(x => x.Name.Equals(username) && x.Password.Equals(password)) != null;
            //}
            return false;
        }

        protected override User GetAuthenticatedUser(IPrincipal principal)
        {
            //principal.Identity.AuthenticationType
            User user = new User()
            {
                Name = principal.Identity.IsAuthenticated ? "true" : "false"
            };

            return user;
        }

        protected override User GetAnonymousUser()
        {
            return new User()
            {
                Name = ""
            };
        }

    }
}
