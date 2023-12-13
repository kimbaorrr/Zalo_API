using System.ComponentModel.DataAnnotations;

namespace Zalo_API.Models
{
    /// <summary>
    /// Đăng nhập
    /// </summary>
    public class Zalo_API_TaiKhoan_DangNhap
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
        /// Default Constructor
        /// </summary>
        public Zalo_API_TaiKhoan_DangNhap()
        {
            this.SDT = string.Empty;
            this.MatKhau = string.Empty;
        }
    }
    /// <summary>
    /// Trả kết quả đăng nhập thành công
    /// </summary>
    public class Zalo_API_TaiKhoan_DangNhap_Success
    {
        /// <summary>
        /// Mã tài khoản
        /// </summary>
        public int Matk { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required]
        [MaxLength(12)]
        [MinLength(8)]
        public string SDT { get; set; }
        /// <summary>
        /// Link ảnh đại diện
        /// </summary>
        public string LinkAvatar { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_TaiKhoan_DangNhap_Success()
        {
            this.Matk = -1;
            this.SDT = string.Empty;
            this.LinkAvatar = string.Empty;
        }
    }

}
