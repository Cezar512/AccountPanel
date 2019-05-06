using System.Threading.Tasks;


namespace L2AccountPanel.Infrastructure.Services
{
    public interface IDataInitializer : IService
    {
         Task SeedAsync();
    }
}