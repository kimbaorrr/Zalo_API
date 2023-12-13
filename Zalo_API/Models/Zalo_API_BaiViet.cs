using Zalo_API_DB;

namespace Zalo_API.Models
{
    /// <summary>
    /// Xem bài viết
    /// </summary>
    public class Zalo_API_XemBaiViet
    {
        /// <summary>
        /// Mã bài viết
        /// </summary>
        public int mabv { get; set; }
        /// <summary>
        /// Nội dung
        /// </summary>
        public string noiDung { get; set; }
        /// <summary>
        /// Tổng lượt like
        /// </summary>
        public int? tongLike { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? ngayTao { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_XemBaiViet()
        {
            this.mabv = -1;
            this.noiDung = string.Empty;
            this.tongLike = 0;
            this.ngayTao = null;
        }
    }
    /// <summary>
    /// Bài viết
    /// </summary>
    public class Zalo_API_BaiViet
    {
        /// <summary>
        /// Lấy danh sách bài viết
        /// </summary>
        /// <returns>Tập List chứa danh sách bài viết</returns>
        internal static List<BaiViet> get_BaiViet()
        {
            try
            {
                return Zalo_API_CSDL.ketNoi()!.BaiViets.ToList();
            }
            catch (Exception ex)
            {
                Zalo_API_CSDL.log_errs(ex.Message);
            }
            return Enumerable.Empty<BaiViet>().ToList();
        }
        /// <summary>
        /// Lấy danh sách các bài viết của tài khoản theo Mã tài khoản
        /// </summary>
        /// <param name="matk">Mã tài khoản</param>
        /// <returns></returns>
        internal static List<Zalo_API_XemBaiViet> get_BaiViet_Theo_MaTK(int matk)
        {
            try
            {
                return get_BaiViet().Where(x => x.NguoiTaoNavigation.Matk == matk).Select(x => new Zalo_API_XemBaiViet
                {
                    mabv = x.Mabv,
                    noiDung = x.NoiDung!,
                    tongLike = x.TongLuotLike,
                    ngayTao = x.NgayTao
                }).ToList();
            }
            catch (Exception ex)
            {
                Zalo_API_CSDL.log_errs(ex.Message);
            }
            return Enumerable.Empty<Zalo_API_XemBaiViet>().ToList();
        }
    }
}
