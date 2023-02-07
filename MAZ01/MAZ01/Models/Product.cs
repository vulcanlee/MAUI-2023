using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAZ01.Models
{
    public partial class Product : ObservableObject, ICloneable
    {
        [ObservableProperty]
        int id;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        short modelYear;
        [ObservableProperty]
        decimal listPrice;

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
