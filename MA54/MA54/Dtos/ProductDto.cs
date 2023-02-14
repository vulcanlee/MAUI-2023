namespace MA54.Dtos;

public class ProductDto : ICloneable
{
    public int Id { get; set; }
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
