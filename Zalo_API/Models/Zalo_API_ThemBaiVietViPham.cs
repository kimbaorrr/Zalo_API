using System.ComponentModel.DataAnnotations;

namespace Zalo_API.Models
{
    /// <summary>
    /// Thêm bài viết vi phạm
    /// </summary>
    public class Zalo_API_ThemBaiVietViPham
    {
        /// <summary>
        /// Mã bài viết
        /// </summary>
        [Required]
        public int Mabv { get; set; }
        /// <summary>
        /// Nội dung vi phạm
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string NoiDungVP { get; set; }
        /// <summary>
        /// Mã tài khoản của người tạo báo cáo
        /// </summary>
        [Required]
        public int NguoiTao { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_ThemBaiVietViPham()
        {
            this.Mabv = -1;
            this.NoiDungVP = string.Empty;
            this.NguoiTao = -1;
        }
    }
}
