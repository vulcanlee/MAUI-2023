using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA53.Models
{
    public partial class Product : ObservableObject, ICloneable
    {
        [ObservableProperty]
        int id = 0;
        [ObservableProperty]
        string name = string.Empty;
        [ObservableProperty]
        short modelYear = 0;
        [ObservableProperty]
        decimal listPrice = 0;

        #region 介面實作
        public Product Clone()
        {
            return ((ICloneable)this).Clone() as Product;
        }
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}
