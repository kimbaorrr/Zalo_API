using System;
using System.Collections.Generic;

namespace Zalo_API_DB;

public partial class XacThucApi
{
    public int Id { get; set; }

    public string? HoTen { get; set; }

    public string TenDn { get; set; } = null!;

    public string? MatKhau { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<LichSuTruyCap> LichSuTruyCaps { get; set; } = new List<LichSuTruyCap>();
}
