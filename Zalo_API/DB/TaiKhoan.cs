using System;
using System.Collections.Generic;

namespace Zalo_API_DB;

public partial class TaiKhoan
{
    public int Matk { get; set; }

    public string? Ten { get; set; }

    public string? MatKhau { get; set; }

    public string? Sdt { get; set; }

    public string? LinkAvatar { get; set; }

    public virtual ICollection<BaiVietViPham> BaiVietViPhams { get; set; } = new List<BaiVietViPham>();

    public virtual ICollection<BaiViet> BaiViets { get; set; } = new List<BaiViet>();

    public virtual ICollection<BanBe> BanBeMatkANavigations { get; set; } = new List<BanBe>();

    public virtual ICollection<BanBe> BanBeMatkBNavigations { get; set; } = new List<BanBe>();

    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    public virtual ICollection<LichSuTruyCap> LichSuTruyCaps { get; set; } = new List<LichSuTruyCap>();

    public virtual ICollection<LikeBaiViet> LikeBaiViets { get; set; } = new List<LikeBaiViet>();

    public virtual ICollection<TinChat> TinChatMatkANavigations { get; set; } = new List<TinChat>();

    public virtual ICollection<TinChat> TinChatMatkBNavigations { get; set; } = new List<TinChat>();

    public virtual ICollection<TaiKhoan> MatkBlockeds { get; set; } = new List<TaiKhoan>();

    public virtual ICollection<TaiKhoan> Matks { get; set; } = new List<TaiKhoan>();
}
