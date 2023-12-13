using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zalo_API.Models;
using Zalo_API_DB;
namespace Zalo_API.Controllers
{
    /// <summary>
    /// Tài khoản
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TaiKhoanController : ControllerBase
    {
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="n_dn">Truyền vào các tham số sau {sdt: Số điện thoại, matKhau: Mật khẩu}</param>
        /// <returns></returns>
        [HttpPost("DangNhap")]
        [Authorize]
        public IActionResult Post_DangNhap(Zalo_API_TaiKhoan_DangNhap n_dn) // login
        {
            if (ModelState.IsValid)
            {
                using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
                {
                    try
                    {
                        n_dn.SDT = Zalo_API_Tools.chuanhoa_SDT(n_dn.SDT).Normalize();
                        string hash_MK = Zalo_API_Tools.hash_MatKhau(n_dn.MatKhau);
                        TaiKhoan a = e.TaiKhoans.FirstOrDefault(x => x.Sdt!.Equals(n_dn.SDT) && x.MatKhau!.Equals(hash_MK))!;
                        if (a != null)
                        {
                            Zalo_API_TaiKhoan_DangNhap_Success dn_ok = new Zalo_API_TaiKhoan_DangNhap_Success()
                            {
                                Matk = a.Matk,
                                SDT = n_dn.SDT,
                                LinkAvatar = a.LinkAvatar!
                            };
                            Zalo_API_Tools.lich_su_truy_cap("Đăng nhập", true, tk_user_id: a.Matk);
                            return Ok(dn_ok);
                        }
                        else
                        {
                            Zalo_API_Tools.lich_su_truy_cap("Đăng nhập", true, api_user_id: a.Matk);
                            return NotFound("Đăng nhập thất bại !");
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
        /// Đăng kí tài khoản mới
        /// </summary>
        /// <param name="n_dk">Truyền vào các tham số sau {sdt: Số điện thoại, matKhau: Mật khẩu (tối thiểu 8 kí tự !), ten: Tên gọi, linkAvatar: Link ảnh đại diện}</param>
        /// <returns></returns>
        [HttpPost("DangKi")]
        [Authorize]
        public IActionResult Post_DangKi(Zalo_API_TaiKhoan_DangKi n_dk) // sign-up
        {
            if (ModelState.IsValid)
            {
                using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
                {
                    try
                    {
                        n_dk.SDT = Zalo_API_Tools.chuanhoa_SDT(n_dk.SDT);
                        if (e.TaiKhoans.Any(x => x.Sdt!.Equals(n_dk.SDT)))
                            return NotFound($"Số điện thoại đã tồn tại !");
                        else
                        {
                            TaiKhoan tk = new TaiKhoan()
                            {
                                Sdt = n_dk.SDT,
                                MatKhau = Zalo_API_Tools.hash_MatKhau(n_dk.MatKhau),
                                Ten = n_dk.Ten,
                                LinkAvatar = n_dk.LinkAvatar
                            };
                            e.TaiKhoans.Add(tk);
                            e.SaveChanges();
                            return Ok(n_dk);
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
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="n_mk">Truyền vào các tham số sau {matk: Mã tài khoản, matKhauCu: Mật khẩu cũ, matKhauMoi: Mật khẩu mới}</param>
        /// <returns></returns>
        [HttpPut("DoiMatKhau")]
        [Authorize]
        public IActionResult Edit_MatKhau(Zalo_API_TaiKhoan_DoiMatKhau n_mk) // change-password
        {
            if (ModelState.IsValid)
            {
                using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
                {
                    try
                    {
                        string mk_cu = Zalo_API_Tools.hash_MatKhau(n_mk.MatKhauCu);
                        string mk_moi = Zalo_API_Tools.hash_MatKhau(n_mk.MatKhauMoi);
                        if (mk_cu.Equals(mk_moi))
                            return NotFound($"Mật khẩu mới không được trùng với Mật khẩu cũ !");
                        TaiKhoan a = e.TaiKhoans.FirstOrDefault(x => x.Matk == n_mk.Matk && x.MatKhau!.Equals(mk_cu))!;
                        if (a == null)
                            return NotFound($"Xác thực tài khoản không thành công !");
                        else
                        {
                            a.MatKhau = mk_moi;
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
    }
}