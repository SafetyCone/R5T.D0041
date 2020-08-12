using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0040;

using R5T.Dacia;


namespace R5T.D0041.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="RemoteRepositoryLocationTypeProvider"/> implementation of <see cref="IRemoteRepositoryLocationTypeProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddRemoteRepositoryLocationTypeProvider(this IServiceCollection services)
        {
            services.AddSingleton<IRemoteRepositoryLocationTypeProvider, RemoteRepositoryLocationTypeProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="RemoteRepositoryLocationTypeProvider"/> implementation of <see cref="IRemoteRepositoryLocationTypeProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IRemoteRepositoryLocationTypeProvider> AddRemoteRepositoryLocationTypeProviderAction(this IServiceCollection services)
        {
            var serviceAction = ServiceAction.New<IRemoteRepositoryLocationTypeProvider>(() => services.AddRemoteRepositoryLocationTypeProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="RemoteRepositoryLocationConverter"/> implementation of <see cref="IRemoteRepositoryLocationConverter"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddRemoteRepositoryLocationConverter(this IServiceCollection services,
            IServiceAction<IRemoteRepositoryLocationTypeProvider> remoteRepositoryLocationTypeProviderAction,
            IServiceAction<IStringlyTypedUrlOperator> stringlyTypedUrlOperatorAction)
        {
            services
                .AddSingleton<IRemoteRepositoryLocationConverter, RemoteRepositoryLocationConverter>()
                .Run(remoteRepositoryLocationTypeProviderAction)
                .Run(stringlyTypedUrlOperatorAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="RemoteRepositoryLocationConverter"/> implementation of <see cref="IRemoteRepositoryLocationConverter"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IRemoteRepositoryLocationConverter> AddRemoteRepositoryLocationConverterAction(this IServiceCollection services,
            IServiceAction<IRemoteRepositoryLocationTypeProvider> remoteRepositoryLocationTypeProviderAction,
            IServiceAction<IStringlyTypedUrlOperator> stringlyTypedUrlOperatorAction)
        {
            var serviceAction = ServiceAction.New<IRemoteRepositoryLocationConverter>(() => services.AddRemoteRepositoryLocationConverter(
                remoteRepositoryLocationTypeProviderAction,
                stringlyTypedUrlOperatorAction));

            return serviceAction;
        }
    }
}
