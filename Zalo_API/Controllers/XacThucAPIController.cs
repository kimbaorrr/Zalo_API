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
    [Route("auth")]
    public class XacThucAPIController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public XacThucAPIController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Đăng nhập API
        /// </summary>
        /// <param name="n_dn_api">Truyền vào các tham số sau {tenDN: Tên đăng nhập, matKhau: Mật khẩu}</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post_DangNhap(Zalo_API_XacThucAPI_DangNhap n_dn_api) // login
        {
            if (ModelState.IsValid)
            {
                using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
                {
                    try
                    {
                        DateTime api_expire = DateTime.UtcNow.AddMinutes(120);
                        n_dn_api.TenDN = n_dn_api.TenDN.Normalize().ToLower();
                        string hash_MK = Zalo_API_Tools.hash_MatKhau(n_dn_api.MatKhau);
                        XacThucApi a = e!.XacThucApis.FirstOrDefault(x => x.TenDn.Equals(n_dn_api.TenDN.Normalize().ToLower()) && x.MatKhau!.Equals(hash_MK))!;
                        if (a != null)
                        {
                            List<Claim> claims = new List<Claim> {
                                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                                new Claim("Id", a.Id.ToString()),
                                new Claim("TenDN", n_dn_api.TenDN),
                                new Claim("NgayTruyCap", DateTime.UtcNow.ToString())
                            };
                            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
                            SigningCredentials signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha384Signature, SecurityAlgorithms.Sha384);
                            JwtSecurityToken token = new JwtSecurityToken(
                                _configuration["Jwt:Issuer"],
                                _configuration["Jwt:Audience"],
                                claims,
                                expires: DateTime.UtcNow.AddMinutes(120),
                                signingCredentials: signIn
                                );
                            Zalo_API_XacThucAPI_DangNhap_Success dn_ok = new Zalo_API_XacThucAPI_DangNhap_Success()
                            {
                                HoTen = a.HoTen!,
                                TenDN = n_dn_api.TenDN,
                                ApiKey = $"Bearer {new JwtSecurityTokenHandler().WriteToken(token)}",
                                Expire = api_expire
                            };
                            Zalo_API_Tools.lich_su_truy_cap("Đăng nhập", true, api_user_id: a.Id);
                            return Ok(dn_ok);
                        }
                        else
                            return NotFound("Đăng nhập thất bại !");                           
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