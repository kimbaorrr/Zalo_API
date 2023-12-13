using System.ComponentModel.DataAnnotations;

namespace Zalo_API.Models
{
    /// <summary>
    /// Đổi mật khẩu
    /// </summary>
    public class Zalo_API_TaiKhoan_DoiMatKhau
    {
        /// <summary>
        /// Mã tài khoản
        /// </summary>
        [Required]
        public int Matk { get; set; }
        /// <summary>
        /// Mật khẩu cũ
        /// </summary>
        [Required]
        [MinLength(8)]
        public string MatKhauCu { get; set; }
        /// <summary>
        /// Mật khẩu mới
        /// </summary>
        [Required]
        [MinLength(8)]
        public string MatKhauMoi { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_TaiKhoan_DoiMatKhau()
        {
            this.Matk = -1;
            this.MatKhauCu = string.Empty;
            this.MatKhauMoi = string.Empty;
        }

    }
}
