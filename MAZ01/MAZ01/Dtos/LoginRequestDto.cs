using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAZ01.Dtos
{
    public class LoginRequestDto : ICloneable
    {
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }

        #region 介面實作
        public LoginRequestDto Clone()
        {
            return ((ICloneable)this).Clone() as LoginRequestDto;
        }
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}
