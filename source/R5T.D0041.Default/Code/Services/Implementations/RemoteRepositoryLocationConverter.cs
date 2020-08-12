using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.D0040;
using R5T.T0010;

using R5T.Magyar.Extensions;


namespace R5T.D0041.Default
{
    public class RemoteRepositoryLocationConverter : IRemoteRepositoryLocationConverter
    {
        public const int SshRemoteRepositoryLocationRequiredTokenCount = 3;


        private IRemoteRepositoryLocationTypeProvider RemoteRepositoryLocationTypeProvider { get; }
        private IStringlyTypedUrlOperator StringlyTypedUrlOperator { get; }


        public RemoteRepositoryLocationConverter(
            IRemoteRepositoryLocationTypeProvider remoteRepositoryLocationTypeProvider,
            IStringlyTypedUrlOperator stringlyTypedUrlOperator)
        {
            this.RemoteRepositoryLocationTypeProvider = remoteRepositoryLocationTypeProvider;
            this.StringlyTypedUrlOperator = stringlyTypedUrlOperator;
        }

        public async Task<string> ToHttps(string sshRemoteRepositoryLocation)
        {
            var isActuallySsh = await this.RemoteRepositoryLocationTypeProvider.IsLocationType(sshRemoteRepositoryLocation, RemoteRepositoryLocationType.SSH);
            if (!isActuallySsh)
            {
                throw new InvalidOperationException($"{nameof(RemoteRepositoryLocationType)} of remote repository location '{sshRemoteRepositoryLocation}' was not {nameof(RemoteRepositoryLocationType.SSH)}");
            }

            var tokens = sshRemoteRepositoryLocation.Split(Constants.RemoteRepositoryLocationTypeTokenSeparators);

            var tokenCount = tokens.Count();
            if (tokenCount != RemoteRepositoryLocationConverter.SshRemoteRepositoryLocationRequiredTokenCount)
            {
                throw new InvalidOperationException($"Unable to convert remote repository location '{sshRemoteRepositoryLocation}'.\nRequired token coung: {RemoteRepositoryLocationConverter.SshRemoteRepositoryLocationRequiredTokenCount}, actual token count: {tokenCount}.");
            }

            var gitToken = tokens[0];
            var githubToken = tokens[1];
            var organizationAndRepositoryPathToken = tokens[2];

            var httpsUrl = this.StringlyTypedUrlOperator.BuildHttpsUrl(githubToken, organizationAndRepositoryPathToken);
            return httpsUrl;
        }

        public async Task<string> ToSsh(string httpsRemoteRepositoryLocation)
        {
            var isActuallyHttps = await this.RemoteRepositoryLocationTypeProvider.IsLocationType(httpsRemoteRepositoryLocation, RemoteRepositoryLocationType.HTTPS);
            if (!isActuallyHttps)
            {
                throw new InvalidOperationException($"{nameof(RemoteRepositoryLocationType)} of remote repository location '{httpsRemoteRepositoryLocation}' was not {nameof(RemoteRepositoryLocationType.HTTPS)}");
            }

            var uri = new Uri(httpsRemoteRepositoryLocation);

            var host = uri.Host;
            var path = uri.AbsolutePath.ExceptFirst(); // Uri.AbsolutePath includes a prefix '/'.

            var sshRemoteRepositoryLocation = $"{Constants.GitName}@{host}:{path}";
            return sshRemoteRepositoryLocation;
        }
    }
}
