using System.ComponentModel.DataAnnotations;

namespace Zalo_API.Models
{
    /// <summary>
    /// Thêm bình luận
    /// </summary>
    public class Zalo_API_ThemBinhLuan
    {
        /// <summary>
        /// Nội dung
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string NoiDung { get; set; }
        /// <summary>
        /// Mã tài khoản của người tạo
        /// </summary>
        [Required]
        public int NguoiTao { get; set; }
        /// <summary>
        /// Mã bài viết
        /// </summary>
        [Required]
        public int Mabv { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_ThemBinhLuan()
        {
            this.NoiDung = string.Empty;
            this.NguoiTao = -1;
            this.Mabv = -1;
        }
    }
}
