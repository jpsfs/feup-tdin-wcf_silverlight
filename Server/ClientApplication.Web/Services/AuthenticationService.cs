namespace ClientApplication.Web
{
    using System.Security.Authentication;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.ServiceModel.DomainServices.Server.ApplicationServices;
    using System.Threading;
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
            Server.ServiceTcpClient client = new Server.ServiceTcpClient();
            bool clientInfo = client.Login(username, password);
            
            return clientInfo;
        }

        protected override User GetAuthenticatedUser(IPrincipal principal)
        {
            var currentUser = base.GetAuthenticatedUser(principal);
            
            Server.ServiceTcpClient client = new Server.ServiceTcpClient();
            Server.ClientInfo clientInfo = client.GetSession(currentUser.Name);

            currentUser.Session = clientInfo.SessionID;
            currentUser.ID = clientInfo.ID.ToString();
            currentUser.Role = ((int)clientInfo.Role).ToString();

            return currentUser;
        }

        protected override User GetAnonymousUser()
        {
            return new User()
            {
                Name = "",
                Session = "",
                FriendlyName = "",
                ID = "",
                Role = ""
            };
        }
    }
}
