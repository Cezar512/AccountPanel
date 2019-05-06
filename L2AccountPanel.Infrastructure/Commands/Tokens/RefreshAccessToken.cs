namespace L2AccountPanel.Infrastructure.Commands.Tokens
{
    public class RefreshAccessToken : ICommand
    {
        public string Token {get; set;}
    }
}