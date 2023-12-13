using System;
using System.Collections.Generic;

namespace Zalo_API_DB;

public partial class BinhLuan
{
    public int Mabl { get; set; }

    public string? NoiDung { get; set; }

    public DateTime? NgayTao { get; set; }

    public int NguoiTao { get; set; }

    public int Mabv { get; set; }

    public virtual BaiViet MabvNavigation { get; set; } = null!;

    public virtual TaiKhoan NguoiTaoNavigation { get; set; } = null!;
}
