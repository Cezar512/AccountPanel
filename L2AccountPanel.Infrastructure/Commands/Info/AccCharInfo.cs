namespace L2AccountPanel.Infrastructure.Commands.Info
{
    public class AccCharInfo : ICommand
    {
        public string Username {get; set;}
        public string CharName {get; set;}
        public int Server {get; set;}

    }
}