using L2AccountPanel.Infrastructure.EF.Models;
using L2AccountPanel.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Design;

namespace L2AccountPanel.Infrastructure.EF
{
    public class L2AccountPanelContext : DbContext
    {
        private readonly MySqlSettings _settings;
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Characters> Characters { get; set; }

        public L2AccountPanelContext(DbContextOptions<L2AccountPanelContext> options, MySqlSettings settings)
                :base(options)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("PRIMARY");

                entity.ToTable("accounts");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.AccessLevel)
                    .HasColumnName("access_level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Hwidblock)
                    .HasColumnName("HWIDBlock")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.HwidblockOn)
                    .HasColumnName("HWIDBlockON")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Ipblock)
                    .HasColumnName("IPBlock")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.LastActive1)
                    .HasColumnName("last_active")
                    .HasColumnType("timestamp");

                entity.Property(e => e.LastIp)
                    .HasColumnName("lastIP")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.LastServer)
                    .HasColumnName("lastServer")
                    .HasColumnType("int(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Lastactive)
                    .HasColumnName("lastactive")
                    .HasColumnType("decimal(20,0)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Serial)
                    .HasColumnName("serial")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Characters>(entity =>
            {
                entity.HasKey(e => e.ObjId)
                    .HasName("PRIMARY");

                entity.ToTable("characters");

                entity.HasIndex(e => e.Clanid)
                    .HasName("clanid");

                entity.Property(e => e.ObjId)
                    .HasColumnName("obj_Id")
                    .HasColumnType("decimal(11,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Acc)
                    .HasColumnName("acc")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Accesslevel)
                    .HasColumnName("accesslevel")
                    .HasColumnType("decimal(4,0)");

                entity.Property(e => e.AccountName)
                    .HasColumnName("account_name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Aio)
                    .HasColumnName("aio")
                    .HasColumnType("decimal(1,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AioEnd)
                    .HasColumnName("aio_end")
                    .HasColumnType("decimal(20,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Apprentice)
                    .HasColumnName("apprentice")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AttackSpeedMultiplier)
                    .HasColumnName("attack_speed_multiplier")
                    .HasColumnType("decimal(10,9)");

                entity.Property(e => e.Autoloot)
                    .HasColumnName("autoloot")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AutolootHerbs)
                    .HasColumnName("autoloot_herbs")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BaseClass)
                    .HasColumnName("base_class")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Blockbuff)
                    .HasColumnName("blockbuff")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Cancraft)
                    .HasColumnName("cancraft")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.CharName)
                    .IsRequired()
                    .HasColumnName("char_name")
                    .HasColumnType("varchar(35)");

                entity.Property(e => e.CharSlot)
                    .HasColumnName("char_slot")
                    .HasColumnType("decimal(1,0)");

                entity.Property(e => e.ClanCreateExpiryTime)
                    .HasColumnName("clan_create_expiry_time")
                    .HasColumnType("decimal(20,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ClanJoinExpiryTime)
                    .HasColumnName("clan_join_expiry_time")
                    .HasColumnType("decimal(20,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ClanPrivs)
                    .HasColumnName("clan_privs")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Clanid)
                    .HasColumnName("clanid")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Classid)
                    .HasColumnName("classid")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.ColHeight)
                    .HasColumnName("colHeight")
                    .HasColumnType("decimal(10,3)");

                entity.Property(e => e.ColRad)
                    .HasColumnName("colRad")
                    .HasColumnType("decimal(10,3)");

                entity.Property(e => e.Con)
                    .HasColumnName("con")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Crit)
                    .HasColumnName("crit")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.CurCp)
                    .HasColumnName("curCp")
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CurHp)
                    .HasColumnName("curHp")
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CurMp)
                    .HasColumnName("curMp")
                    .HasColumnType("decimal(18,0)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DeathPenaltyLevel)
                    .HasColumnName("death_penalty_level")
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Deletetime)
                    .HasColumnName("deletetime")
                    .HasColumnType("decimal(20,0)");

                entity.Property(e => e.Dex)
                    .HasColumnName("dex")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Evasion)
                    .HasColumnName("evasion")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Exp)
                    .HasColumnName("exp")
                    .HasColumnType("decimal(20,0)");

                entity.Property(e => e.ExpBeforeDeath)
                    .HasColumnName("expBeforeDeath")
                    .HasColumnType("decimal(20,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Face)
                    .HasColumnName("face")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.FirstLog)
                    .HasColumnName("first_log")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Gainexp)
                    .HasColumnName("gainexp")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Glow)
                    .HasColumnName("glow")
                    .HasColumnType("int(1)");

                entity.Property(e => e.HairColor)
                    .HasColumnName("hairColor")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.HairStyle)
                    .HasColumnName("hairStyle")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Heading)
                    .HasColumnName("heading")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.HitmanTarget)
                    .HasColumnName("hitman_target")
                    .HasColumnType("int(16)");

                entity.Property(e => e.Int)
                    .HasColumnName("_int")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Isin7sdungeon)
                    .HasColumnName("isin7sdungeon")
                    .HasColumnType("decimal(1,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Karma)
                    .HasColumnName("karma")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.LastAccess)
                    .HasColumnName("lastAccess")
                    .HasColumnType("decimal(20,0)");

                entity.Property(e => e.LastRecomDate)
                    .HasColumnName("last_recom_date")
                    .HasColumnType("decimal(20,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.LvlJoinedAcademy)
                    .HasColumnName("lvl_joined_academy")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MAtk)
                    .HasColumnName("mAtk")
                    .HasColumnType("decimal(20,0)");

                entity.Property(e => e.MDef)
                    .HasColumnName("mDef")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.MSpd)
                    .HasColumnName("mSpd")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.MaxCp)
                    .HasColumnName("maxCp")
                    .HasColumnType("decimal(11,0)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MaxHp)
                    .HasColumnName("maxHp")
                    .HasColumnType("decimal(11,0)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MaxMp)
                    .HasColumnName("maxMp")
                    .HasColumnType("decimal(11,0)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Maxload)
                    .HasColumnName("maxload")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Men)
                    .HasColumnName("men")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.MovementMultiplier)
                    .HasColumnName("movement_multiplier")
                    .HasColumnType("decimal(9,8)");

                entity.Property(e => e.NameColor)
                    .IsRequired()
                    .HasColumnName("name_color")
                    .HasColumnType("varchar(8)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Newbie)
                    .HasColumnName("newbie")
                    .HasColumnType("decimal(1,0)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Nobless)
                    .HasColumnName("nobless")
                    .HasColumnType("decimal(1,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Online)
                    .HasColumnName("online")
                    .HasColumnType("decimal(1,0)");

                entity.Property(e => e.Onlinetime)
                    .HasColumnName("onlinetime")
                    .HasColumnType("decimal(20,0)");

                entity.Property(e => e.PAtk)
                    .HasColumnName("pAtk")
                    .HasColumnType("decimal(20,0)");

                entity.Property(e => e.PDef)
                    .HasColumnName("pDef")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.PSpd)
                    .HasColumnName("pSpd")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.PcPoint)
                    .HasColumnName("pc_point")
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Pkkills)
                    .HasColumnName("pkkills")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Pm)
                    .HasColumnName("pm")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PowerGrade)
                    .HasColumnName("power_grade")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.PunishLevel)
                    .HasColumnName("punish_level")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PunishTimer)
                    .HasColumnName("punish_timer")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Pvpkills)
                    .HasColumnName("pvpkills")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Race)
                    .HasColumnName("race")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.RecHave)
                    .HasColumnName("rec_have")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RecLeft)
                    .HasColumnName("rec_left")
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RunSpd)
                    .HasColumnName("runSpd")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Screentxt)
                    .HasColumnName("screentxt")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Sp)
                    .HasColumnName("sp")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Sponsor)
                    .HasColumnName("sponsor")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Str)
                    .HasColumnName("str")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Subpledge)
                    .HasColumnName("subpledge")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Teleport)
                    .HasColumnName("teleport")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TitleColor)
                    .IsRequired()
                    .HasColumnName("title_color")
                    .HasColumnType("varchar(8)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Titlestatus)
                    .HasColumnName("titlestatus")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Trade)
                    .HasColumnName("trade")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.VarkaKetraAlly)
                    .HasColumnName("varka_ketra_ally")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.WalkSpd)
                    .HasColumnName("walkSpd")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Wantspeace)
                    .HasColumnName("wantspeace")
                    .HasColumnType("decimal(1,0)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Wit)
                    .HasColumnName("wit")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Y)
                    .HasColumnName("y")
                    .HasColumnType("decimal(11,0)");

                entity.Property(e => e.Z)
                    .HasColumnName("z")
                    .HasColumnType("decimal(11,0)");
            });
        }
    }
}