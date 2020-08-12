using System;
using System.Threading.Tasks;

using R5T.T0010;


namespace R5T.D0041
{
    public static class IRemoteRepositoryLocationTypeProviderExtensions
    {
        public static async Task<bool> IsLocationType(this IRemoteRepositoryLocationTypeProvider remoteRepositoryLocationTypeProvider,
            string remoteRepositoryLocation, RemoteRepositoryLocationType remoteRepositoryLocationType)
        {
            var actualRemoteRepositoryLocationType = await remoteRepositoryLocationTypeProvider.GetRemoteRepositoryLocationType(remoteRepositoryLocation);

            var isLocationType = actualRemoteRepositoryLocationType == remoteRepositoryLocationType;
            return isLocationType;
        }
    }
}
