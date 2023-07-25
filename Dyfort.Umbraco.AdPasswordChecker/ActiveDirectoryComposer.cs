using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Security;
using Umbraco.Extensions;

namespace Dyfort.Umbraco.AdPasswordChecker
{
    public class ActiveDirectoryComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddOptions<ActiveDirectorySettings>().Bind(builder.Config.GetSection(ActiveDirectorySettings.SectionName));

            var activeDirectorySettings = builder.Config.GetSection(ActiveDirectorySettings.SectionName).Get<ActiveDirectorySettings>();

            if (activeDirectorySettings != null && activeDirectorySettings.Enabled)
            {
                builder.Services.AddUnique<IBackOfficeUserPasswordChecker, ActiveDirectoryPasswordChecker>();
            }
        }
    }
}