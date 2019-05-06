namespace L2AccountPanel.Infrastructure.Commands.Accounts
{
    public class CreateAccount : ICommand
    {
        public string Email {get; set;}
        public string Password {get; set;}
        public string Username {get; set;}
        public string Role {get; set;} = "user";
    }
}