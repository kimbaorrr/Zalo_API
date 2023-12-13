using System;
using System.Collections.Generic;

namespace Zalo_API_DB;

public partial class BaiViet
{
    public int Mabv { get; set; }

    public string? NoiDung { get; set; }

    public int NguoiTao { get; set; }

    public DateTime? NgayTao { get; set; }

    public int? TongLuotLike { get; set; }

    public virtual ICollection<BaiVietViPham> BaiVietViPhams { get; set; } = new List<BaiVietViPham>();

    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    public virtual ICollection<LikeBaiViet> LikeBaiViets { get; set; } = new List<LikeBaiViet>();

    public virtual TaiKhoan NguoiTaoNavigation { get; set; } = null!;
}
