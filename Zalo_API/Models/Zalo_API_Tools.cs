using Org.BouncyCastle.Crypto.Digests;
using System.Text;
using Zalo_API_DB;
using Zalo_API.Models;

namespace Zalo_API.Models
{
    public class Zalo_API_Tools
    {
        /// <summary>
        /// Băm mật khẩu + Salt
        /// </summary>
        /// <param name="matkhau">Mật khẩu gốc</param>
        /// <returns>Mật khẩu đã băm</returns>
        internal static string hash_MatKhau(string matkhau)
        {
            try
            {
                Sha3Digest hash = new Sha3Digest(512);
                byte[] input = Encoding.ASCII.GetBytes($"haha{matkhau}hihi@@@");
                hash.BlockUpdate(input, 0, input.Length);
                byte[] result = new byte[64];
                hash.DoFinal(result, 0);
                return BitConverter.ToString(result).Replace("-", "").ToLower();
            }
            catch (Exception ex)
            {
                Zalo_API_CSDL.log_errs(ex.Message);
            }
            return string.Empty;
        }
        /// <summary>
        /// Chuẩn hóa SĐT (đầu 0 => +84)
        /// </summary>
        /// <param name="sdt">Số điện thoại</param>
        /// <returns></returns>
        internal static string chuanhoa_SDT(string sdt)
        {
            if (sdt.StartsWith("0"))
            {
                sdt = sdt.Substring(1);
                sdt = $"+84{sdt}";
            }
            return sdt;
        }
        internal static void lich_su_truy_cap(string? loai=null, bool? trangThai=null, int? tk_user_id=null, int? api_user_id=null)
        {
            try
            {
                using (Zalo_API_Entities e = Zalo_API_CSDL.ketNoi()!)
                {
                    LichSuTruyCap a = new LichSuTruyCap()
                    {
                        Loai = loai,
                        TrangThai = trangThai,
                        TkUserId = tk_user_id,
                        ApiUserId = api_user_id,
                    };
                    e.Add(a);
                    e.SaveChanges();
                }
            } catch (Exception ex)
            {
                Zalo_API_CSDL.log_errs(ex.Message);
            }
        }
    }
}
