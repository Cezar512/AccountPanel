namespace L2AccountPanel.Infrastructure.DTO
{
    public class JwtTokenDTO
    {
        public string AccessToken { get; set; }
        public long Expires { get; set; }
    }
}