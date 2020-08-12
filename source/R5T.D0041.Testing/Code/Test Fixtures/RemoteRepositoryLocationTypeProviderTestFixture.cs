using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.T0010;
using R5T.T0011;

using R5T.Magyar;


namespace R5T.D0041.Testing
{
    public abstract class RemoteRepositoryLocationTypeProviderTestFixture : ServiceTestFixtureBase<IRemoteRepositoryLocationTypeProvider>
    {
        private IRemoteRepositoryLocationTypeProvider RemoteRepositoryLocationTypeProvider => this.Service; // More specific name for convenience.


        public RemoteRepositoryLocationTypeProviderTestFixture(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        /// <summary>
        /// Tests that 
        /// </summary>
        [TestMethod]
        public async Task TestIsLocationType()
        {
            var isHttps = await this.RemoteRepositoryLocationTypeProvider.IsLocationType(Constants.HttpsRemoteRepositoryLocation, RemoteRepositoryLocationType.HTTPS);
            var isNotSsh01 = await this.RemoteRepositoryLocationTypeProvider.IsLocationType(Constants.HttpsRemoteRepositoryLocation, RemoteRepositoryLocationType.SSH);
            var isNotUnknown01 = await this.RemoteRepositoryLocationTypeProvider.IsLocationType(Constants.HttpsRemoteRepositoryLocation, RemoteRepositoryLocationType.Unknown);

            var isNotHttps02 = await this.RemoteRepositoryLocationTypeProvider.IsLocationType(Constants.SshRemoteRepositoryLocation, RemoteRepositoryLocationType.HTTPS);
            var isSsh = await this.RemoteRepositoryLocationTypeProvider.IsLocationType(Constants.SshRemoteRepositoryLocation, RemoteRepositoryLocationType.SSH);
            var isNotUnknown02 = await this.RemoteRepositoryLocationTypeProvider.IsLocationType(Constants.SshRemoteRepositoryLocation, RemoteRepositoryLocationType.Unknown);

            var isNotHttps03 = await this.RemoteRepositoryLocationTypeProvider.IsLocationType(Constants.UnknownRemoteRepositoryLocation, RemoteRepositoryLocationType.HTTPS);
            var isNotSsh03 = await this.RemoteRepositoryLocationTypeProvider.IsLocationType(Constants.UnknownRemoteRepositoryLocation, RemoteRepositoryLocationType.SSH);
            var isUnknown = await this.RemoteRepositoryLocationTypeProvider.IsLocationType(Constants.UnknownRemoteRepositoryLocation, RemoteRepositoryLocationType.Unknown);

            var trues = new[]
            {
                isHttps,
                isSsh,
                isUnknown,
            };

            trues.ForEach(x => Assert.IsTrue(x));

            var falses = new[]
            {
                isNotHttps02,
                isNotHttps03,
                isNotSsh01,
                isNotSsh03,
                isNotUnknown01,
                isNotUnknown02,
            };

            falses.ForEach(x => Assert.IsFalse(x));
        }
    }
}
