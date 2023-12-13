using System.ComponentModel.DataAnnotations;

namespace Zalo_API.Models
{
    /// <summary>
    /// Thêm bài viết
    /// </summary>
    public class Zalo_API_ThemBaiViet
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
        /// Default Constructor
        /// </summary>
        public Zalo_API_ThemBaiViet()
        {
            this.NoiDung = string.Empty;
            this.NguoiTao = -1;
        }
    }
}
