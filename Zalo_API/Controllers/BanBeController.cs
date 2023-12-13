using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Zalo_API.Models;
namespace Zalo_API.Controllers
{
    /// <summary>
    /// Bạn bè
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BanBeController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách bạn bè theo tài khoản
        /// </summary>
        /// <param name="matk">Mã tài khoản</param>
        /// <returns></returns>
        [HttpGet("DSTheoMaTK/{matk}")]
        public IActionResult Get_BanBe_Matk(int matk) // get_user_friends
        {
            List<Zalo_API_XemBanBe> bb = Zalo_API_BanBe.get_BanBe_Theo_MaTK(matk);
            return Ok(JsonConvert.SerializeObject(bb));
        }
        /// <summary>
        /// Tìm kiếm bạn bè bằng Tên hoặc SĐT
        /// </summary>
        /// <param name="search">Tên hoặc SĐT</param>
        /// <returns></returns>
        [HttpGet("TimKiem/{search}")]
        public IActionResult TimKiemBanBe(string search) // search
        {
            List<Zalo_API_TimBanBe> bb = Zalo_API_BanBe.TimKiemBanBe(search);
            return Ok(JsonConvert.SerializeObject(bb));
        }
    }
}