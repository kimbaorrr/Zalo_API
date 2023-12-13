using Zalo_API_DB;

namespace Zalo_API.Models
{
    /// <summary>
    /// Xem bạn bè
    /// </summary>
    public class Zalo_API_XemBanBe
    {
        /// <summary>
        /// Tên của bạn bè
        /// </summary>
        public string tenGoi { get; set; }
        /// <summary>
        /// Số điện thoại của bạn bè
        /// </summary>
        public string sdt { get; set; }
        /// <summary>
        /// Ngày thêm
        /// </summary>
        public DateTime? ngayThem { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_XemBanBe()
        {
            this.tenGoi = string.Empty;
            this.sdt = string.Empty;
            this.ngayThem = null;
        }
    }
    /// <summary>
    /// Tìm bạn bè
    /// </summary>
    public class Zalo_API_TimBanBe
    {
        /// <summary>
        /// Mã tài khoản
        /// </summary>
        public int matk { get; set; }
        /// <summary>
        /// Tên gọi
        /// </summary>
        public string tenGoi { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string sdt { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_TimBanBe()
        {
            this.matk = -1;
            this.tenGoi = string.Empty;
            this.sdt = string.Empty;
        }
    }
    /// <summary>
    /// Bài viết
    /// </summary>
    public class Zalo_API_BanBe
    {
        /// <summary>
        /// Lấy danh sách bạn bè
        /// </summary>
        /// <returns>Tập List chứa danh sách bài viết</returns>
        internal static List<BanBe> get_BanBe()
        {
            try
            {
                return Zalo_API_CSDL.ketNoi()!.BanBes.ToList();
            }
            catch (Exception ex)
            {
                Zalo_API_CSDL.log_errs(ex.Message);
            }
            return Enumerable.Empty<BanBe>().ToList();
        }
        /// <summary>
        /// Lấy danh sách bạn bè của tài khoản
        /// </summary>
        /// <param name="matk">Mã tài khoản A</param>
        /// <returns></returns>
        internal static List<Zalo_API_XemBanBe> get_BanBe_Theo_MaTK(int matk)
        {
            try
            {
                return get_BanBe().Where(x => x.MatkANavigation.Matk == matk).Select(x => new Zalo_API_XemBanBe
                {
                    tenGoi = x.MatkBNavigation.Ten!,
                    ngayThem = x.NgayThem
                }).ToList();
            }
            catch (Exception ex)
            {
                Zalo_API_CSDL.log_errs(ex.Message);
            }
            return Enumerable.Empty<Zalo_API_XemBanBe>().ToList();
        }
        /// <summary>
        /// Tìm kiếm bạn bè bằng Tên hoặc SĐT
        /// </summary>
        /// <param name="search">Tên hoặc SĐT</param>
        /// <returns></returns>
        internal static List<Zalo_API_TimBanBe> TimKiemBanBe(string search)
        {
            try
            {
                return Zalo_API_CSDL.ketNoi()!.TaiKhoans.Where(x => x.Ten!.ToLower().Contains(search.ToLower()) || x.Sdt!.Contains(Zalo_API_Tools.chuanhoa_SDT(search))).Select(x => new Zalo_API_TimBanBe
                {
                    matk = x.Matk,
                    sdt = x.Sdt!,
                    tenGoi = x.Ten!
                }).ToList();
            }
            catch (Exception ex)
            {
                Zalo_API_CSDL.log_errs(ex.Message);
            }
            return Enumerable.Empty<Zalo_API_TimBanBe>().ToList();
        }

    }
}
