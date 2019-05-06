namespace L2AccountPanel.Infrastructure.Commands.Accounts
{
    public class Login : ICommand
    {
        public string Password {get; set;}
        public string Username {get; set;}       
    }
}