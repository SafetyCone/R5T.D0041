using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0040;
using R5T.D0040.Default;
using R5T.D0041.Default;

using R5T.Dacia;


namespace R5T.D0041.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IRemoteRepositoryLocationConverter"/> service.
        /// </summary>
        public static 
            (
            IServiceAction<IRemoteRepositoryLocationConverter> Main,
            IServiceAction<IRemoteRepositoryLocationTypeProvider> RemoteRepositoryLocationTypeProviderAction,
            IServiceAction<IStringlyTypedUrlOperator> StringlyTypedUrlOperatorAction
            )
        AddRemoteRepositoryLocationConverterAction(this IServiceCollection services)
        {
            // 0.
            var stringlyTypedUrlOperatorAction = services.AddStringlyTypedUrlOperatorAction();
            var remoteRepositoryLocationTypeProviderAction = services.AddRemoteRepositoryLocationTypeProviderAction();

            // 1.
            var remoteRepositoryLocationConverterAction = services.AddRemoteRepositoryLocationConverterAction(
                remoteRepositoryLocationTypeProviderAction,
                stringlyTypedUrlOperatorAction);

            return
                (
                remoteRepositoryLocationConverterAction,
                remoteRepositoryLocationTypeProviderAction,
                stringlyTypedUrlOperatorAction
                );
        }

        /// <summary>
        /// Adds the <see cref="IRemoteRepositoryLocationConverter"/> service.
        /// </summary>
        public static IServiceCollection AddRemoteRepositoryLocationConverter(this IServiceCollection services)
        {
            var remoteRepositoryLocationConverterAction = services.AddRemoteRepositoryLocationConverterAction();

            services
                .Run(remoteRepositoryLocationConverterAction.Main)
                ;

            return services;
        }
    }
}
