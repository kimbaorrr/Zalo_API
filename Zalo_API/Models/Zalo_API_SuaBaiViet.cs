namespace Zalo_API.Models
{
    /// <summary>
    /// Sửa bài viết
    /// </summary>
    public class Zalo_API_SuaBaiViet
    {
        public int Mabv { get; set; }
        public string NoiDung { get; set; }
        public string ThongBaoLoi { get; set; } // Chứa thông báo lỗi điều kiện
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_SuaBaiViet()
        {
            this.Mabv = -1;
            this.NoiDung = string.Empty;
            this.ThongBaoLoi = string.Empty;
        }
    }
}
