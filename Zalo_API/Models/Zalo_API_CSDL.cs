using Zalo_API_DB;
namespace Zalo_API.Models
{
    public class Zalo_API_CSDL
    {
        /// <summary>
        /// Khởi tạo và lưu trữ đối tượng Entities
        /// </summary>
        /// <returns>Entities</returns>
        public static Zalo_API_Entities? ketNoi()
        {
            try
            {
                Zalo_API_Entities e = new Zalo_API_Entities();
                return e;
            }
            catch (Exception ex)
            {
                log_errs(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Ghi nhận các lỗi vào tệp Zalo_API_Errors.txt tại ổ đĩa D:\
        /// </summary>
        /// <param name="message">Thông tin lỗi</param>
        public static void log_errs(string message)
            => File.AppendAllText("Zalo_API_Errors.txt", "\n" + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + "\t" + message);

    }
}
