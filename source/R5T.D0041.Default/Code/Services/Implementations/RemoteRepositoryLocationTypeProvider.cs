using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0010;using R5T.T0064;


namespace R5T.D0041.Default
{[ServiceImplementationMarker]
    public class RemoteRepositoryLocationTypeProvider : IRemoteRepositoryLocationTypeProvider,IServiceImplementation
    {
        public const string HttpsIndicatorLowered = "https";
        public const string GitIndicatorLowered = Constants.GitName;


        public Task<RemoteRepositoryLocationType> GetRemoteRepositoryLocationType(string remoteRepositoryLocation)
        {
            var tokens = remoteRepositoryLocation.Split(Constants.RemoteRepositoryLocationTypeTokenSeparators);

            // If no tokens, return unknown.
            var anyTokens = tokens.Any();
            if (!anyTokens)
            {
                return Task.FromResult(RemoteRepositoryLocationType.Unknown);
            }

            var firstToken = tokens.First();

            var firstTokenLowered = firstToken.ToLowerInvariant();

            switch (firstTokenLowered)
            {
                case RemoteRepositoryLocationTypeProvider.HttpsIndicatorLowered:
                    return Task.FromResult(RemoteRepositoryLocationType.HTTPS);

                case RemoteRepositoryLocationTypeProvider.GitIndicatorLowered:
                    return Task.FromResult(RemoteRepositoryLocationType.SSH);

                default:
                    return Task.FromResult(RemoteRepositoryLocationType.Unknown);
            }
        }
    }
}
