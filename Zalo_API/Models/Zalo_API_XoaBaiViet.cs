using System.ComponentModel.DataAnnotations;

namespace Zalo_API.Models
{
    /// <summary>
    /// Xóa bài viết
    /// </summary>
    public class Zalo_API_XoaBaiViet
    {
        /// <summary>
        /// Mã bài viết
        /// </summary>
        [Required]
        public int Mabv { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_XoaBaiViet()
        {
            this.Mabv = -1;
        }
    }
}
