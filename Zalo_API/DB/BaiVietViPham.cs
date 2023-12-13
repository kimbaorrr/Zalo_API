using System;
using System.Collections.Generic;

namespace Zalo_API_DB;

public partial class BaiVietViPham
{
    public int Mabv { get; set; }

    public string? NoiDungVp { get; set; }

    public int TkReport { get; set; }

    public DateTime NgayTao { get; set; }

    public virtual BaiViet MabvNavigation { get; set; } = null!;

    public virtual TaiKhoan TkReportNavigation { get; set; } = null!;
}
