using System;
using System.Collections.Generic;

namespace Zalo_API_DB;

public partial class LikeBaiViet
{
    public int Id { get; set; }

    public int Matk { get; set; }

    public int Mabv { get; set; }

    public DateTime? NgayLike { get; set; }

    public virtual BaiViet MabvNavigation { get; set; } = null!;

    public virtual TaiKhoan MatkNavigation { get; set; } = null!;
}
