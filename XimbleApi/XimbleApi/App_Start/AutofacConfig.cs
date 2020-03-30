    using Autofac;
    using Autofac.Integration.WebApi;
    using System.Reflection;
    using System.Web.Http;
    using XimbleApi.Models;
    using XimbleApi.Models.Repository.Contracts;
    using XimbleApi.Models.Repository;

    namespace XimbleApi.App_Start
    {
        public class AutofacConfig
        {
            public static void Register()
            {
                var builder = new ContainerBuilder();

                // Get your HttpConfiguration.
                var config = GlobalConfiguration.Configuration;

                // Register your Web API controllers.
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

                RegisterService(builder);

                // OPTIONAL: Register the Autofac filter provider.
                builder.RegisterWebApiFilterProvider(config);

                // OPTIONAL: Register the Autofac model binder provider.
                builder.RegisterWebApiModelBinderProvider();

                // Set the dependency resolver to be Autofac.
                var container = builder.Build();
                config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            }

            public static void RegisterService(ContainerBuilder builder)
            {
                builder.RegisterType<AdventureWorksContext>().InstancePerRequest();

                builder.RegisterType<ProductRepository>()
                    .As<IProductRepository>().InstancePerRequest();

                builder.RegisterType<RepositoryWrapper>()
                    .As<IRepositoryWrapper>().InstancePerRequest();

                builder.RegisterType<PurchaseOrderDetailRepository>()
                    .As<IPurchaseOrderDetailRepository>().InstancePerRequest();
            }
        }
    }