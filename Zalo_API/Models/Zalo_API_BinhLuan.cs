using Zalo_API_DB;
namespace Zalo_API.Models
{
    /// <summary>
    /// Xem bình luận
    /// </summary>
    public class Zalo_API_XemBinhLuan
    {
        /// <summary>
        /// Nội dung
        /// </summary>
        public string noiDung { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? ngayTao { get; set; }
        public Zalo_API_XemBinhLuan()
        {
            this.noiDung = string.Empty;
            this.ngayTao = null;
        }
    }
    /// <summary>
    /// Danh sách bình luận theo Mã bình luận
    /// </summary>
    public class Zalo_API_DSBinhLuan_MaBV
    {
        /// <summary>
        /// Tên tài khoản
        /// </summary>
        public string tenTK { get; set; }
        /// <summary>
        /// Nội dung
        /// </summary>
        public string noiDung { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? ngayTao { get; set; }
        public Zalo_API_DSBinhLuan_MaBV()
        {
            this.tenTK = string.Empty;
            this.noiDung = string.Empty;
            this.ngayTao = null;
        }
    }

    public class Zalo_API_BinhLuan
    {
        internal static List<BinhLuan> get_BinhLuan()
        {
            try
            {
                return Zalo_API_CSDL.ketNoi()!.BinhLuans.ToList();
            }
            catch (Exception ex)
            {
                Zalo_API_CSDL.log_errs(ex.Message);
            }
            return Enumerable.Empty<BinhLuan>().ToList();
        }
        /// <summary>
        /// Lấy danh sách các bình luận về bài viết nào đó theo tài khoản
        /// </summary>
        /// <param name="matk">Mã tài khoản</param>
        /// <param name="mabv">Mã bài viết</param>
        /// <returns></returns>
        internal static List<Zalo_API_XemBinhLuan>? get_BinhLuan_Theo_MaTK_MaBV(int matk, int mabv)
        {
            try
            {
                return get_BinhLuan().Where(x => x.NguoiTaoNavigation.Matk == matk && x.Mabv == mabv).Select(x => new Zalo_API_XemBinhLuan
                {
                    noiDung = x.NoiDung!,
                    ngayTao = x.NgayTao
                }).ToList();
            }
            catch (Exception ex)
            {
                Zalo_API_CSDL.log_errs(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Lấy danh sách tất cả các bình luận của bài viết
        /// </summary>
        /// <param name="mabv">Mã bài viết</param>
        /// <returns></returns>
        internal static List<Zalo_API_DSBinhLuan_MaBV> get_DSBinhLuan_Theo_MaBV(int mabv)
        {
            try
            {
                return get_BinhLuan().Where(x => x.Mabv == mabv).Select(x => new Zalo_API_DSBinhLuan_MaBV
                {
                    tenTK = x.NguoiTaoNavigation.Ten!,
                    noiDung = x.NoiDung!,
                    ngayTao = x.NgayTao
                }).ToList();
            }
            catch (Exception ex)
            {
                Zalo_API_CSDL.log_errs(ex.Message);
            }
            return Enumerable.Empty<Zalo_API_DSBinhLuan_MaBV>().ToList();
        }

    }
}
