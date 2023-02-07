using MAZ01.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAZ01.Models
{
    public class JwtStoreModel
    {
        public LoginResponseDto LoginResponseDto { get; set; } = new();
        public DateTime TokenExpireAtTime { get; set; }
        public DateTime RefreshTokenExpireAtTime { get; set; }
    }
}
