namespace L2AccountPanel.Infrastructure.DTO
{
    public class AccountCharacterInfoDTO
    {
        public string Login { get;  set; }
        public string CharName { get; set; }
        public string LastIp { get;  set; }
        public decimal? Level { get; set; }
        public decimal? MaxHp { get; set; }
        public decimal? MaxCp { get; set; }
        public decimal? MaxMp { get; set; }
        public decimal? Sex { get; set; }
        public decimal? Pvpkills { get; set; }
        public decimal? Pkkills { get; set; }
        public decimal? Classid { get; set; }
        public string Title { get; set; }
    }
}