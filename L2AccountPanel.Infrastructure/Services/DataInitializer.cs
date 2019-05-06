using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace L2AccountPanel.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IAccountService _accountService;
        private readonly ICharacterService _characterService;
        private readonly IAccountCharacterInfoService _infoService;

        public DataInitializer(IAccountService accountService, ICharacterService characterService, IAccountCharacterInfoService infoService)   //dodac settingsy z adminem.
        {
            _accountService = accountService;
            _characterService = characterService;
            _infoService = infoService;
        }

        public async Task SeedAsync()
        {
            var accounts = await _accountService.BrowseAsync();
            Random random = new Random();
            if(accounts.Any())
            {
                Console.WriteLine("Data was already initialized.");

                return; 
            }
            //var info = await _infoService.GetAsync("user1","user208890",1);

            Console.WriteLine("Initializing data...");    
            //var tasks = new List<Task>();
            var adminId = Guid.NewGuid();
            await _accountService.RegisterAsync(adminId,$"admin@admin.com","admin123","admin","admin");
            for(var i=1; i<=10; i++)
            {
                var server = random.Next(0,3);
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                await _accountService.RegisterAsync(userId,$"user{i}@test.com","secret",username,"user");
                    for(var j =0; j<=3; j++)
                    {
                        await _characterService.AddAsync(userId, $"user{random.Next(55,555555)}", server);
                    }                
                Console.WriteLine($"Adding user: '{username}'.");
            }
             Console.WriteLine("Data was initialized."); 
        }   
    }
}