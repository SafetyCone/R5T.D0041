using System;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using R5T.D0041.Testing;


namespace R5T.D0041.Default.Testing
{
    [TestClass]
    public class RemoteRepositoryLocationConverterTests : RemoteRepositoryLocationConverterTestFixture
    {
        #region Static

        private static ServiceProvider ServiceProvider { get; set; }


        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            RemoteRepositoryLocationConverterTests.ServiceProvider = Utilities.GetServiceProvider();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            RemoteRepositoryLocationConverterTests.ServiceProvider.Dispose();
        }

        #endregion


        public RemoteRepositoryLocationConverterTests()
            : base(RemoteRepositoryLocationConverterTests.ServiceProvider)
        {
        }
    }
}
