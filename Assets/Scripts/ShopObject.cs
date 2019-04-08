using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Assets.Scripts.ShopTypeEnum;
/// <summary>
/// Objeto de la lista de la compra.
/// </summary>
public class ShopObject : MonoBehaviour
{
    /// <summary>
    /// Nombre del objeto.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Tipo de tienda que pertenece
    /// </summary>
    public ShopType ShopType { get; set; }

    public ShopObject() { }

    public ShopObject(string name, ShopType shopType)
    {
        Name = name;
        ShopType = shopType;
    }
}
