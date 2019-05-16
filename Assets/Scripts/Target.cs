using UnityEngine;
using static ShopTypeEnum;

[RequireComponent(typeof(BoxCollider2D))]
public class Target : MonoBehaviour
{
    [SerializeField]
    private ShopType _type;
    // Start is called before the first frame update

    public ShopType Type { get => _type; set => _type = value; }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
