namespace Zalo_API.Models
{
    /// <summary>
    /// Sửa bình luận
    /// </summary>
    public class Zalo_API_SuaBinhLuan
    {
        public int Mabl { get; set; }
        public string NoiDung { get; set; }
        public string ThongBaoLoi { get; set; } // Chứa thông báo lỗi điều kiện
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_SuaBinhLuan()
        {
            this.Mabl = -1;
            this.NoiDung = string.Empty;
            this.ThongBaoLoi = string.Empty;
        }
    }
}
