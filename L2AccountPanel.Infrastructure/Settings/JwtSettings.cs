namespace L2AccountPanel.Infrastructure.Settings
{
    public  class JwtSettings
    {
        public  string Key {get; set;}
        public  int ExpiryMinutes {get; set;}
        public  string Issuer {get; set;}
    }
}