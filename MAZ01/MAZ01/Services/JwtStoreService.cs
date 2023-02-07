using MAZ01.Dtos;
using MAZ01.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAZ01.Services
{
    public class JwtStoreService
    {
        /// <summary>
        /// 儲存此次使用者通過身分驗證後的 JWT 相關資訊
        /// </summary>
        public JwtStoreModel JwtStore { get; set; } = new();
        string jwtFilename = "jwt.data";

        /// <summary>
        /// 設定要儲存的 JWT 相關資訊
        /// </summary>
        /// <param name="loginResponseDto"></param>
        public void SetJwt(LoginResponseDto loginResponseDto)
        {
            this.JwtStore.LoginResponseDto = loginResponseDto;
            this.JwtStore.TokenExpireAtTime = DateTime.Now
                .AddMinutes(this.JwtStore.LoginResponseDto.TokenExpireMinutes);
            this.JwtStore.RefreshTokenExpireAtTime = DateTime.Now
                .AddDays(this.JwtStore.LoginResponseDto.RefreshTokenExpireDays);
        }

        /// <summary>
        /// 從檔案內讀取 JWT 相關資訊
        /// </summary>
        /// <returns></returns>
        public async Task ReadAsync()
        {
            string file = Path.Combine(FileSystem.Current.AppDataDirectory, jwtFilename);
            JwtStore = new();
            try
            {
                string content = await File.ReadAllTextAsync(file);
                JwtStore = JsonConvert.DeserializeObject<JwtStoreModel>(content);
            }
            catch { }
        }

        /// <summary>
        /// 將 JWT 相關資訊寫入到檔案內
        /// </summary>
        /// <returns></returns>
        public async Task<bool> WriteAsync()
        {
            string file = Path.Combine(FileSystem.Current.AppDataDirectory, jwtFilename);
            try
            {
                string content = JsonConvert.SerializeObject(JwtStore);
                await File.WriteAllTextAsync(file, content);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// 將 JWT 相關資訊儲存檔案刪除掉
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            string file = Path.Combine(FileSystem.Current.AppDataDirectory, jwtFilename);
            try
            {
                File.Delete(file);
                return true;
            }
            catch { return false; }
        }
    }
}
