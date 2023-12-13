using System;
using System.Collections.Generic;

namespace Zalo_API_DB;

public partial class BanBe
{
    public int MatkA { get; set; }

    public int MatkB { get; set; }

    public DateTime? NgayThem { get; set; }

    public virtual TaiKhoan MatkANavigation { get; set; } = null!;

    public virtual TaiKhoan MatkBNavigation { get; set; } = null!;
}
