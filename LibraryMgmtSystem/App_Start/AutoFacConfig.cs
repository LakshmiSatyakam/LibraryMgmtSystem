using Autofac;
using Autofac.Integration.WebApi;
using LibraryMgmtSystem.Models;
using LibraryMgmtSystem.Repositories;
using LibraryMgmtSystem.Services;
using System.Reflection;
using System.Web.Http;
using IContainer = Autofac.IContainer;

namespace LibraryMgmtSystem.App_Start
{
    /// <summary>
    /// AutoFac config class
    /// </summary>
    public class AutoFacConfig
    {
        #region Public fields

        /// <summary>
        /// Container instance
        /// </summary>
        public static IContainer Container;

        #endregion

        #region Pubic static methods

        /// <summary>
        /// Initializes the config
        /// </summary>
        /// <param name="config"></param>
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        /// <summary>
        /// Initializes the config
        /// </summary>
        /// <param name="config"></param>
        /// <param name="container"></param>
        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        #endregion

        #region Private static  methods

        /// <summary>
        /// Registers all the dependencies
        /// </summary>
        /// <param name="builder">builder object</param>
        /// <returns>Container with all the registrations</returns>
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<BooksService>()
                   .As<IBooksService>()
                   .InstancePerRequest();

            builder.RegisterType<BooksAssignService>()
                   .As<IBooksAssignService>()
                   .InstancePerRequest();

            builder.RegisterType<BooksRenewService>()
                   .As<IBooksRenewService>()
                   .InstancePerRequest();

            builder.RegisterType<StudentsService>()
                   .As<IStudentsService>()
                   .InstancePerRequest();

            builder.RegisterType<BooksRepository>()
                   .As<IBooksRepository<Book>>()
                   .InstancePerRequest();

            builder.RegisterType<StudentsRepository>()
                  .As<IStudentsRepository<Student>>()
                  .InstancePerRequest();

            builder.RegisterType<AssignDetailsRepository>()
                   .As<IAssignDetailsRepository<AssignDetails>>()
                   .InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        } 

        #endregion
    }
}