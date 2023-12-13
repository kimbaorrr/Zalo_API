using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Zalo_API.Models;
using Zalo_API_DB;
namespace Zalo_API.Controllers
{
    /// <summary>
    /// Bài viết
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BaiVietController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách các bài viết của tài khoản
        /// </summary>
        /// <param name="matk">Mã tài khoản</param>
        /// <returns></returns>
        [HttpGet("DSTheoMaTK/{matk}")]
        public IActionResult Get_BaiViet_Matk(int matk) // get_list_post
        {
            List<Zalo_API_XemBaiViet> bv = Zalo_API_BaiViet.get_BaiViet_Theo_MaTK(matk);
            return Ok(JsonConvert.SerializeObject(bv));
        }
        /// <summary>
        /// Thêm một bài viết
        /// </summary>
        /// <param name="n_bv">Truyền vào các tham số sau {noiDung: Nội dung, nguoiTao: Mã tài khoản}</param>
        /// <returns></returns>
        [HttpPost("ThemBaiViet")]
        public IActionResult Post_BaiViet(Zalo_API_ThemBaiViet n_bv) // add_post
        {
            if (ModelState.IsValid)
            {
                using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
                {
                    try
                    {
                        BaiViet bv = new BaiViet()
                        {
                            NoiDung = n_bv.NoiDung,
                            NguoiTao = n_bv.NguoiTao
                        };
                        e.BaiViets.Add(bv);
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
        /// Báo cáo một bài viết vi phạm
        /// </summary>
        /// <param name="n_bvvp">Truyền vào các tham số sau {noiDung: Nội dung, nguoiTao: Mã tài khoản}</param>
        /// <returns></returns>
        [HttpPost("BaoCaoViPham")]
        public IActionResult Post_BaiVietViPham(Zalo_API_ThemBaiVietViPham n_bvvp) // add_post
        {
            if (ModelState.IsValid)
            {
                using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
                {
                    try
                    {
                        if (!e.BaiViets.Any(x => x.Mabv == n_bvvp.Mabv))
                            return NotFound($"Không tìm thấy bài viết {n_bvvp.Mabv}");
                        else
                        {
                            BaiVietViPham bvvp = new BaiVietViPham()
                            {
                                Mabv = n_bvvp.Mabv,
                                NoiDungVp = n_bvvp.NoiDungVP,
                                TkReport = n_bvvp.NguoiTao
                            };
                            e.BaiVietViPhams.Add(bvvp);
                            e.SaveChanges();
                            return Ok(ModelState);
                        }
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
        /// Xóa một bài viết
        /// </summary>
        /// <param name="mabv">Mã bài viết</param>
        /// <returns></returns>
        [HttpDelete("XoaBaiViet/{mabv}")]
        public IActionResult Delete_BaiViet(int mabv) // delete_post
        {
            using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
            {
                try
                {
                    BaiViet bv = e.BaiViets.FirstOrDefault(x => x.Mabv == mabv)!;
                    if (bv == null)
                        return NotFound($"Không tìm thấy bài viết {mabv} !");
                    else
                    {
                        e.BaiViets.Remove(bv);
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
        /// Sửa một bài viết
        /// </summary>
        /// <param name="mabv">Mã bài viết</param>
        /// <param name="noi_dung">Nội dung mới</param>
        /// <returns></returns>
        [HttpPut("SuaBaiViet/{mabv}/{noi_dung}")]
        public IActionResult Edit_BaiViet(int mabv, string noi_dung) // edit_post
        {
            using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
            {
                try
                {
                    BaiViet bv = e.BaiViets.FirstOrDefault(x => x.Mabv == mabv)!;
                    if (bv == null)
                        return NotFound($"Không tìm thấy bài viết {mabv} !");
                    else
                    {
                        bv.NoiDung = noi_dung;
                        bv.NgayTao = DateTime.Now;
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