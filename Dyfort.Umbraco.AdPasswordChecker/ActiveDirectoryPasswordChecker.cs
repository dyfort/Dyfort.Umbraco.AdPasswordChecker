using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.DirectoryServices.Protocols;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Security;

namespace Dyfort.Umbraco.AdPasswordChecker
{
    public class ActiveDirectoryPasswordChecker : IBackOfficeUserPasswordChecker
    {
        private readonly ILogger<ActiveDirectoryPasswordChecker> logger;
        private readonly ActiveDirectorySettings activeDirectorySettings;

        public ActiveDirectoryPasswordChecker(ILogger<ActiveDirectoryPasswordChecker> logger, IOptions<ActiveDirectorySettings> activeDirectorySettings)
        {
            this.logger = logger;
            this.activeDirectorySettings = activeDirectorySettings.Value;
        }

        public Task<BackOfficeUserPasswordCheckerResult> CheckPasswordAsync(BackOfficeIdentityUser user, string password)
        {
            var username = user.UserName;
            logger.LogInformation("Start password check for {username}", username);

            try
            {
                using var lconn = new LdapConnection(new LdapDirectoryIdentifier(activeDirectorySettings.Domain));
                lconn.Bind(new System.Net.NetworkCredential(username, password, activeDirectorySettings.Domain));
                return Task.FromResult(BackOfficeUserPasswordCheckerResult.ValidCredentials);
            }
            catch (LdapException e)
            {
                logger.LogError(e, "Login failed for {username}", username);
                return Task.FromResult(BackOfficeUserPasswordCheckerResult.InvalidCredentials);
            }
        }
    }
}
