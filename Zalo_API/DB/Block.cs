namespace Zalo_API_DB;

public partial class Block
{
    public int? Matk { get; set; }

    public int? MatkBlocked { get; set; }

    public virtual TaiKhoan? MatkBlockedNavigation { get; set; }

    public virtual TaiKhoan? MatkNavigation { get; set; }
}
