using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Zalo_API_DB;

public partial class Zalo_API_Entities : DbContext
{
    public Zalo_API_Entities()
    {
    }

    public Zalo_API_Entities(DbContextOptions<Zalo_API_Entities> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiViet> BaiViets { get; set; }

    public virtual DbSet<BaiVietViPham> BaiVietViPhams { get; set; }

    public virtual DbSet<BanBe> BanBes { get; set; }

    public virtual DbSet<BinhLuan> BinhLuans { get; set; }

    public virtual DbSet<LichSuTruyCap> LichSuTruyCaps { get; set; }

    public virtual DbSet<LikeBaiViet> LikeBaiViets { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TinChat> TinChats { get; set; }

    public virtual DbSet<XacThucApi> XacThucApis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=192.168.1.2;Port=5432;Database=zalo_api;Username=k_zalo;Password=dK8rcOj0Cl7vftiX#;SSLMode=Allow;Integrated Security=true;Persist Security Info=true;Timezone=Asia/Bangkok;Encoding=UTF8;Client Encoding=UTF8");
        optionsBuilder.UseLazyLoadingProxies();
    }        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiViet>(entity =>
        {
            entity.HasKey(e => e.Mabv).HasName("bai_viet_pkey");

            entity.ToTable("bai_viet");

            entity.Property(e => e.Mabv)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, 12L, null, null, null, null)
                .HasColumnName("mabv");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.NguoiTao).HasColumnName("nguoi_tao");
            entity.Property(e => e.NoiDung)
                .HasMaxLength(255)
                .HasColumnName("noi_dung");
            entity.Property(e => e.TongLuotLike)
                .HasDefaultValueSql("0")
                .HasColumnName("tong_luot_like");

            entity.HasOne(d => d.NguoiTaoNavigation).WithMany(p => p.BaiViets)
                .HasForeignKey(d => d.NguoiTao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bai_viet_nguoi_tao_fkey");
        });

        modelBuilder.Entity<BaiVietViPham>(entity =>
        {
            entity.HasKey(e => e.NgayTao).HasName("pk_ngay_tao");

            entity.ToTable("bai_viet_vi_pham");

            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.Mabv).HasColumnName("mabv");
            entity.Property(e => e.NoiDungVp)
                .HasMaxLength(255)
                .HasColumnName("noi_dung_vp");
            entity.Property(e => e.TkReport).HasColumnName("tk_report");

            entity.HasOne(d => d.MabvNavigation).WithMany(p => p.BaiVietViPhams)
                .HasForeignKey(d => d.Mabv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bai_viet_vi_pham_mabv_fkey");

            entity.HasOne(d => d.TkReportNavigation).WithMany(p => p.BaiVietViPhams)
                .HasForeignKey(d => d.TkReport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bai_viet_vi_pham_tk_report_fkey");
        });

        modelBuilder.Entity<BanBe>(entity =>
        {
            entity.HasKey(e => new { e.MatkA, e.MatkB }).HasName("pk_ban_be");

            entity.ToTable("ban_be");

            entity.Property(e => e.MatkA).HasColumnName("matk_a");
            entity.Property(e => e.MatkB).HasColumnName("matk_b");
            entity.Property(e => e.NgayThem)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngay_them");

            entity.HasOne(d => d.MatkANavigation).WithMany(p => p.BanBeMatkANavigations)
                .HasForeignKey(d => d.MatkA)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ban_be_matk_a_fkey");

            entity.HasOne(d => d.MatkBNavigation).WithMany(p => p.BanBeMatkBNavigations)
                .HasForeignKey(d => d.MatkB)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ban_be_matk_b_fkey");
        });

        modelBuilder.Entity<BinhLuan>(entity =>
        {
            entity.HasKey(e => e.Mabl).HasName("binh_luan_pkey");

            entity.ToTable("binh_luan");

            entity.Property(e => e.Mabl)
                .UseIdentityAlwaysColumn()
                .HasColumnName("mabl");
            entity.Property(e => e.Mabv).HasColumnName("mabv");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.NguoiTao).HasColumnName("nguoi_tao");
            entity.Property(e => e.NoiDung)
                .HasMaxLength(255)
                .HasColumnName("noi_dung");

            entity.HasOne(d => d.MabvNavigation).WithMany(p => p.BinhLuans)
                .HasForeignKey(d => d.Mabv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("binh_luan_mabv_fkey");

            entity.HasOne(d => d.NguoiTaoNavigation).WithMany(p => p.BinhLuans)
                .HasForeignKey(d => d.NguoiTao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("binh_luan_nguoi_tao_fkey");
        });

        modelBuilder.Entity<LichSuTruyCap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lich_su_truy_cap_pkey");

            entity.ToTable("lich_su_truy_cap");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ApiUserId).HasColumnName("api_user_id");
            entity.Property(e => e.Loai)
                .HasMaxLength(50)
                .HasColumnName("loai");
            entity.Property(e => e.ThoiGian)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("thoi_gian");
            entity.Property(e => e.TkUserId).HasColumnName("tk_user_id");
            entity.Property(e => e.TrangThai).HasColumnName("trang_thai");

            entity.HasOne(d => d.ApiUser).WithMany(p => p.LichSuTruyCaps)
                .HasForeignKey(d => d.ApiUserId)
                .HasConstraintName("lich_su_truy_cap_api_user_id_fkey");

            entity.HasOne(d => d.TkUser).WithMany(p => p.LichSuTruyCaps)
                .HasForeignKey(d => d.TkUserId)
                .HasConstraintName("lich_su_truy_cap_tk_user_id_fkey");
        });

        modelBuilder.Entity<LikeBaiViet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("like_bai_viet_pkey");

            entity.ToTable("like_bai_viet");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Mabv).HasColumnName("mabv");
            entity.Property(e => e.Matk).HasColumnName("matk");
            entity.Property(e => e.NgayLike)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngay_like");

            entity.HasOne(d => d.MabvNavigation).WithMany(p => p.LikeBaiViets)
                .HasForeignKey(d => d.Mabv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("like_bai_viet_mabv_fkey");

            entity.HasOne(d => d.MatkNavigation).WithMany(p => p.LikeBaiViets)
                .HasForeignKey(d => d.Matk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("like_bai_viet_matk_fkey");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Matk).HasName("tai_khoan_pkey");

            entity.ToTable("tai_khoan");

            entity.HasIndex(e => e.Sdt, "uni_tai_khoan").IsUnique();

            entity.Property(e => e.Matk)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, null, 18000000L, 310000000L, null, null)
                .HasColumnName("matk");
            entity.Property(e => e.LinkAvatar)
                .HasDefaultValueSql("'assets/default.jpg'::text")
                .HasColumnName("link_avatar");
            entity.Property(e => e.MatKhau).HasColumnName("mat_khau");
            entity.Property(e => e.Sdt)
                .HasMaxLength(12)
                .HasColumnName("sdt");
            entity.Property(e => e.Ten)
                .HasMaxLength(50)
                .HasColumnName("ten");

            entity.HasMany(d => d.MatkBlockeds).WithMany(p => p.Matks)
                .UsingEntity<Dictionary<string, object>>(
                    "Block",
                    r => r.HasOne<TaiKhoan>().WithMany()
                        .HasForeignKey("MatkBlocked")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("blocks_matk_blocked_fkey"),
                    l => l.HasOne<TaiKhoan>().WithMany()
                        .HasForeignKey("Matk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("blocks_matk_fkey"),
                    j =>
                    {
                        j.HasKey("Matk", "MatkBlocked").HasName("pk_blocks");
                        j.ToTable("blocks");
                        j.IndexerProperty<int>("Matk").HasColumnName("matk");
                        j.IndexerProperty<int>("MatkBlocked").HasColumnName("matk_blocked");
                    });

            entity.HasMany(d => d.Matks).WithMany(p => p.MatkBlockeds)
                .UsingEntity<Dictionary<string, object>>(
                    "Block",
                    r => r.HasOne<TaiKhoan>().WithMany()
                        .HasForeignKey("Matk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("blocks_matk_fkey"),
                    l => l.HasOne<TaiKhoan>().WithMany()
                        .HasForeignKey("MatkBlocked")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("blocks_matk_blocked_fkey"),
                    j =>
                    {
                        j.HasKey("Matk", "MatkBlocked").HasName("pk_blocks");
                        j.ToTable("blocks");
                        j.IndexerProperty<int>("Matk").HasColumnName("matk");
                        j.IndexerProperty<int>("MatkBlocked").HasColumnName("matk_blocked");
                    });
        });

        modelBuilder.Entity<TinChat>(entity =>
        {
            entity.HasKey(e => e.Matc).HasName("tin_chat_pkey");

            entity.ToTable("tin_chat");

            entity.Property(e => e.Matc)
                .UseIdentityAlwaysColumn()
                .HasColumnName("matc");
            entity.Property(e => e.MatkA).HasColumnName("matk_a");
            entity.Property(e => e.MatkB).HasColumnName("matk_b");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.NoiDung)
                .HasMaxLength(255)
                .HasColumnName("noi_dung");

            entity.HasOne(d => d.MatkANavigation).WithMany(p => p.TinChatMatkANavigations)
                .HasForeignKey(d => d.MatkA)
                .HasConstraintName("tin_chat_matk_a_fkey");

            entity.HasOne(d => d.MatkBNavigation).WithMany(p => p.TinChatMatkBNavigations)
                .HasForeignKey(d => d.MatkB)
                .HasConstraintName("tin_chat_matk_b_fkey");
        });

        modelBuilder.Entity<XacThucApi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("xac_thuc_api_pkey");

            entity.ToTable("xac_thuc_api");

            entity.HasIndex(e => e.TenDn, "xac_thuc_api_ten_dn_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.HoTen)
                .HasMaxLength(100)
                .HasColumnName("ho_ten");
            entity.Property(e => e.MatKhau).HasColumnName("mat_khau");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.TenDn)
                .HasMaxLength(50)
                .HasColumnName("ten_dn");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
