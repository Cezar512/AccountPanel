using Autofac;
using L2AccountPanel.Infrastructure.Extensions;
using L2AccountPanel.Infrastructure.Mongo;
using L2AccountPanel.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;


namespace L2AccountPanel.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>()).SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<MySqlSettings>()).SingleInstance();
        }
    }
}