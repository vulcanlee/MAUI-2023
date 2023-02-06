using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAZ01.Dtos
{
    public class ProductDto : ICloneable
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "商品名稱 欄位必須要輸入值")]
        public string Name { get; set; }
        public short ModelYear { get; set; }
        public decimal ListPrice { get; set; }

        #region 介面實作
        public ProductDto Clone()
        {
            return ((ICloneable)this).Clone() as ProductDto;
        }
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}
