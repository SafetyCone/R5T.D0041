using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.T0011;


namespace R5T.D0041.Testing
{
    public abstract class RemoteRepositoryLocationConverterTestFixture : ServiceTestFixtureBase<IRemoteRepositoryLocationConverter>
    {
        protected IRemoteRepositoryLocationConverter RemoteRepositoryLocationConverter => this.Service; // More specific name for convenience.


        protected RemoteRepositoryLocationConverterTestFixture(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        /// <summary>
        /// Tests that we can round-trip convert HTTPS and SSH remote repository locations.
        /// </summary>
        [TestMethod]
        public async Task RoundTripHttpsAndSsh()
        {
            var nowSsh = await this.RemoteRepositoryLocationConverter.ToSsh(Constants.HttpsRemoteRepositoryLocation);
            var backToHttps = await this.RemoteRepositoryLocationConverter.ToHttps(nowSsh);

            var nowHttps = await this.RemoteRepositoryLocationConverter.ToHttps(Constants.SshRemoteRepositoryLocation);
            var backToSsh = await this.RemoteRepositoryLocationConverter.ToSsh(nowHttps);

            Assert.AreEqual(backToHttps, Constants.HttpsRemoteRepositoryLocation);
            Assert.AreEqual(backToSsh, Constants.SshRemoteRepositoryLocation);
        }
    }
}
