using System;
using System.Collections.Generic;

namespace Zalo_API_DB;

public partial class TinChat
{
    public int Matc { get; set; }

    public string? NoiDung { get; set; }

    public int? MatkA { get; set; }

    public int? MatkB { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual TaiKhoan? MatkANavigation { get; set; }

    public virtual TaiKhoan? MatkBNavigation { get; set; }
}
