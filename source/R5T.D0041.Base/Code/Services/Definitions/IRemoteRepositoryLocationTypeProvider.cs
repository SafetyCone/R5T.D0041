using System;
using System.Threading.Tasks;

using R5T.T0010;
using R5T.T0064;


namespace R5T.D0041
{
    [ServiceDefinitionMarker]
    public interface IRemoteRepositoryLocationTypeProvider : IServiceDefinition
    {
        Task<RemoteRepositoryLocationType> GetRemoteRepositoryLocationType(string remoteRepositoryLocation);
    }
}
