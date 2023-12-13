using System.ComponentModel.DataAnnotations;

namespace Zalo_API.Models
{
    /// <summary>
    /// Đăng nhập API
    /// </summary>
    public class Zalo_API_XacThucAPI_DangNhap
    {
        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string TenDN { get; set; }
        /// <summary>
        /// Mật khẩu
        /// </summary>
        [Required]
        [MinLength(8)]
        public string MatKhau { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_XacThucAPI_DangNhap()
        {
            this.TenDN = string.Empty;
            this.MatKhau = string.Empty;
        }
    }
    /// <summary>
    /// Trả kết quả đăng nhập thành công
    /// </summary>
    public class Zalo_API_XacThucAPI_DangNhap_Success
    {
        /// <summary>
        /// Họ tên
        /// </summary>
        [Required]
        public string HoTen { get; set; }
        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        [Required]
        public string TenDN { get; set; }
        /// <summary>
        /// Khóa xác thực để dùng API
        /// </summary>
        [Required]
        public string ApiKey { get; set; }
        /// <summary>
        /// Thời gian tồn tại của ApiKey
        /// </summary>
        [Required]
        public DateTime Expire { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_XacThucAPI_DangNhap_Success()
        {
            this.HoTen = string.Empty;
            this.TenDN = string.Empty;
            this.ApiKey = string.Empty;
            this.Expire = DateTime.Now;
        }
    }

}
