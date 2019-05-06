using System.Reflection;
using Autofac;
using L2AccountPanel.Infrastructure.Mongo;
using L2AccountPanel.Infrastructure.Repositories;
using MongoDB.Driver;


namespace L2AccountPanel.Infrastructure.IoC.Modules
{
    public class MongoModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c,p)=>
            {
                var settings = c.Resolve<MongoSettings>();

                return new MongoClient(settings.connectionString);
            }).SingleInstance();

             builder.Register((c,p)=>
            {
                var client = c.Resolve<MongoClient>();
                var settings = c.Resolve<MongoSettings>();
                var database = client.GetDatabase(settings.database);

                return database;
            }).As<IMongoDatabase>();           

            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IMongoRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}