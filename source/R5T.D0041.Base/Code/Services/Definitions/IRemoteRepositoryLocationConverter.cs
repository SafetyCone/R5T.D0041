using System;
using System.Threading.Tasks;

using R5T.T0064;


namespace R5T.D0041
{
    [ServiceDefinitionMarker]
    public interface IRemoteRepositoryLocationConverter : IServiceImplementation
    {
        Task<string> ToHttps(string sshRemoteRepositoryLocation);
        Task<string> ToSsh(string httpsRemoteRepositoryLocation);
    }
}
