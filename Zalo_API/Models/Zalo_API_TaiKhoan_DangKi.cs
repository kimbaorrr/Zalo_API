using System.ComponentModel.DataAnnotations;
namespace Zalo_API.Models
{
    /// <summary>
    /// Đăng kí
    /// </summary>
    public class Zalo_API_TaiKhoan_DangKi
    {
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required]
        [MaxLength(12)]
        [MinLength(8)]
        public string SDT { get; set; }
        /// <summary>
        /// Mật khẩu
        /// </summary>
        [Required]
        [MinLength(8)]
        public string MatKhau { get; set; }
        /// <summary>
        /// Tên gọi
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Ten { get; set; }
        /// <summary>
        /// Link Avatar
        /// </summary>
        public string LinkAvatar { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_TaiKhoan_DangKi()
        {
            this.SDT = string.Empty;
            this.MatKhau = string.Empty;
            this.Ten = string.Empty;
            this.LinkAvatar = "assets/default.jpg";
        }
    }
}
