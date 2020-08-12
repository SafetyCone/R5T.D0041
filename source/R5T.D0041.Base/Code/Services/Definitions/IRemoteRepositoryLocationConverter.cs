using System;
using System.Threading.Tasks;


namespace R5T.D0041
{
    public interface IRemoteRepositoryLocationConverter
    {
        Task<string> ToHttps(string sshRemoteRepositoryLocation);
        Task<string> ToSsh(string httpsRemoteRepositoryLocation);
    }
}
