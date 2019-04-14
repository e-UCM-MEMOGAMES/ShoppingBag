using System;
using static ShopTypeEnum;
/// <summary>
/// Objeto de la lista de la compra.
/// </summary>
public class ShopObject
{
    /// <summary>
    /// Nombre del objeto.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Tipo de tienda que pertenece
    /// </summary>
    public ShopType ShopType { get; set; }

    public ShopObject()
    {
    }

    public ShopObject(string name, ShopType shopType)
    {
        Name = name;
        ShopType = shopType;
    }

    /// <summary>
    /// Comparador
    /// </summary>
    /// <param name="obj">Objeto a comparar</param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        ShopObject c = obj as ShopObject;
        if (c == null)
            return false;
        return (Name == c.Name && ShopType == c.ShopType);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
