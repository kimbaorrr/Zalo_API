using System;
using System.Collections.Generic;

namespace Zalo_API_DB;

public partial class LichSuTruyCap
{
    public int Id { get; set; }

    public string? Loai { get; set; }

    public int? TkUserId { get; set; }

    public int? ApiUserId { get; set; }

    public DateTime? ThoiGian { get; set; }

    public bool? TrangThai { get; set; }

    public virtual XacThucApi? ApiUser { get; set; }

    public virtual TaiKhoan? TkUser { get; set; }
}
