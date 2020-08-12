using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0040.Default;

using R5T.Dacia;


namespace R5T.D0041.Default.Testing
{
    public static class Utilities
    {
        public static ServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            // 0.
            var remoteRepositoryLocationTypeProviderAction = services.AddRemoteRepositoryLocationTypeProviderAction();
            var stringlyTypedUrlOperatorAction = services.AddStringlyTypedUrlOperatorAction();

            // 1.
            var remoteRepositoryLocationConverterAction = services.AddRemoteRepositoryLocationConverterAction(
                remoteRepositoryLocationTypeProviderAction,
                stringlyTypedUrlOperatorAction);

            services
                .Run(remoteRepositoryLocationConverterAction)
                ;

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
