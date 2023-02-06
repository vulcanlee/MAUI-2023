﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAZ01.Dtos
{
    public class MyUserDto : ICloneable
    {
        public string Account { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;

        #region 介面實作
        public MyUserDto Clone()
        {
            return ((ICloneable)this).Clone() as MyUserDto;
        }
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}
