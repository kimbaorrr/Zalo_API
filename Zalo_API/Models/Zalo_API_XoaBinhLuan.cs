using System.ComponentModel.DataAnnotations;

namespace Zalo_API.Models
{
    /// <summary>
    /// Xóa bình luận
    /// </summary>
    public class Zalo_API_XoaBinhLuan
    {
        /// <summary>
        /// Mã bình luận
        /// </summary>
        [Required]
        public int Mabl { get; set; }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Zalo_API_XoaBinhLuan()
        {
            this.Mabl = -1;
        }
    }
}
