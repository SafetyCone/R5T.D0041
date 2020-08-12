using System;
using System.Threading.Tasks;

using R5T.T0010;


namespace R5T.D0041
{
    public interface IRemoteRepositoryLocationTypeProvider
    {
        Task<RemoteRepositoryLocationType> GetRemoteRepositoryLocationType(string remoteRepositoryLocation);
    }
}
