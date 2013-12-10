using System.Configuration;
using Autofac;
using Core.Data;

namespace Core.Infrastructure
{
    public class AutofacCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(DocumentRepository).Assembly)
                .InstancePerDependency()
                .AsImplementedInterfaces();

            builder.RegisterType<DocumentRepository>().As<IDocumentRepository>()
              .WithParameter(new NamedParameter("rootPath", ConfigurationManager.AppSettings["rootPath"]));
        }
    }
}
