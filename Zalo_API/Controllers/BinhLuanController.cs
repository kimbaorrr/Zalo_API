using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Zalo_API.Models;
using Zalo_API_DB;

namespace Zalo_API.Controllers
{
    /// <summary>
    /// Bình luận
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BinhLuanController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách các bình luận về một bài viết nào đó
        /// </summary>
        /// <param name="mabv">Mã bài viết</param>
        /// <returns></returns>
        [HttpGet("DSTheoMaBV/{mabv}")]
        public IActionResult Get_DSBinhLuan_MaBV(int mabv) // get_comment
        {
            List<Zalo_API_DSBinhLuan_MaBV> bl = Zalo_API_BinhLuan.get_DSBinhLuan_Theo_MaBV(mabv);
            return Ok(JsonConvert.SerializeObject(bl));
        }
        /// <summary>
        /// Lấy danh sách các bình luận của một tài khoản về một bài viết nào đó
        /// </summary>
        /// <param name="matk">Mã tài khoản</param>
        /// <param name="mabv">Mã bài viết</param>
        /// <returns></returns>
        [HttpGet("DSTheoMaTK_MaBV/{matk}/{mabv}")]
        public IActionResult Get_BinhLuan_Matk_Mabv(int matk, int mabv)
        {
            List<Zalo_API_XemBinhLuan> bl = Zalo_API_BinhLuan.get_BinhLuan_Theo_MaTK_MaBV(matk, mabv)!;
            return Ok(JsonConvert.SerializeObject(bl));
        }
        /// <summary>
        /// Thêm một bình luận mới
        /// </summary>
        /// <param name="n_bl">Truyền vào các tham số sau {noiDung: Nội dung, nguoiTao: Mã tài khoản, mabv: Mã bài viết cần bình luận}</param>
        /// <returns></returns>
        [HttpPost("ThemBinhLuan")]
        public IActionResult Post_BinhLuan(Zalo_API_ThemBinhLuan n_bl) // add_comment
        {
            if (ModelState.IsValid)
            {
                using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
                {
                    try
                    {
                        BinhLuan bl = new BinhLuan()
                        {
                            NoiDung = n_bl.NoiDung,
                            NguoiTao = n_bl.NguoiTao,
                            Mabv = n_bl.Mabv
                        };
                        e.BinhLuans.Add(bl);
                        e.SaveChanges();
                        return Ok(ModelState);
                    }
                    catch (Exception ex)
                    {
                        Zalo_API_CSDL.log_errs(ex.Message);
                    }
                }
            }
            return BadRequest(ModelState);
        }
        /// <summary>
        /// Xóa một bình luận
        /// </summary>
        /// <param name="mabl">Mã bình luận</param>
        /// <returns></returns>
        [HttpDelete("XoaBinhLuan/{mabl}")]
        public IActionResult Delete_BinhLuan(int mabl) // delete_comment
        {
            using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
            {
                try
                {
                    BinhLuan bl = e.BinhLuans.FirstOrDefault(x => x.Mabl == mabl)!;
                    if (bl == null)
                        return NotFound($"Không tìm thấy bình luận {mabl} !");
                    else
                    {
                        e.BinhLuans.Remove(bl);
                        e.SaveChanges();
                        return Ok(ModelState);
                    }
                }
                catch (Exception ex)
                {
                    Zalo_API_CSDL.log_errs(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
        /// <summary>
        /// Sửa một bình luận
        /// </summary>
        /// <param name="mabl">Mã bình luận</param>
        /// <param name="noi_dung">Nội dung mới</param>
        /// <returns></returns>

        [HttpPut("SuaBinhLuan/{mabl}/{noi_dung}")]
        public IActionResult Edit_BinhLuan(int mabl, string noi_dung) // edit_comment
        {
            using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
            {
                try
                {
                    BinhLuan bl = e.BinhLuans.FirstOrDefault(x => x.Mabl == mabl)!;
                    if (bl == null)
                        return NotFound($"Không tìm thấy bình luận {mabl} !");
                    else
                    {
                        bl.NoiDung = noi_dung;
                        bl.NgayTao = DateTime.Now;
                        e.SaveChanges();
                        return Ok(ModelState);
                    }
                }
                catch (Exception ex)
                {
                    Zalo_API_CSDL.log_errs(ex.Message);
                }
            }
            return BadRequest(ModelState);
        }
    }
}