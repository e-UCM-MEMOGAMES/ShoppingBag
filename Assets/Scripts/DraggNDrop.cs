using UnityEngine;
using UnityEngine.SceneManagement;
using static ShopTypeEnum;

public class DraggNDrop : MonoBehaviour
{
    #region Variables Unity

    [SerializeField]
    private ShopType _type;
    [SerializeField]
    private string _name;
    #endregion

    #region Constantes
    public ShopObject ShopObject { get; set; }
    #endregion

    #region Eventos
    // Start is called before the first frame update
    void Start()
    {
        ShopObject = new ShopObject(_name, _type);
        //Debug.Log("############### Start");
        Debug.Log("############### ShopObject - " + ShopObject.Name);
        Debug.Log("############### CurrentObject - " + GM.Gm.CurrentObject.Name);
        if (ShopObject.Name == GM.Gm.CurrentObject.Name)
        {
            gameObject.SetActive(true);
            Debug.Log("############### Start true");
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("############### Start false");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
            throw new System.ArgumentNullException(nameof(collision));
        else
        {
            Debug.Log("############### Collision enter");
            if (collision.gameObject.Equals(ShopObject.ShopType))
                GM.Gm.CorrectShop(ShopObject);
            else
                GM.Gm.WrongShop(ShopObject);
            GM.Gm.NextObject();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == null)
            throw new System.ArgumentNullException(nameof(collision));
        else
        {
            if (GM.Gm.ShopList.Count == 0)
                SceneManager.LoadScene("############### Result");
        }
    }

    #endregion
}