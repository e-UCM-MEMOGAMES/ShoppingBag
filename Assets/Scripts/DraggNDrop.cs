using System;
using UnityEngine;
using static ShopTypeEnum;

[RequireComponent(typeof(PolygonCollider2D))]
public class DraggNDrop : MonoBehaviour
{
    #region Variables Unity

    [SerializeField]
    private ShopType _type;
    [SerializeField]
    private string _name;

    [SerializeField]
    private LevelManager _levelManager;

    #endregion

    #region Constantes

    public ShopObject ShopObject { get; set; }

    private float OFFSET_Z { get { return 10.0f; } }

    #endregion

    #region Atributos

    public bool ItsInTarget { get; set; }

    /// <summary>
    /// Posición inicial del movimiento.
    /// </summary>
    private Vector3 StartPoint { get; set; }

    /// <summary>
    /// Posición actual del movimiento.
    /// </summary>
    private Vector3 Offset { get; set; }

    private Collider2D Collision { get; set; }

    private LevelManager LevelManager { get => _levelManager; }

    #endregion

    #region Eventos
    // Start is called before the first frame update
    void Start()
    {
        ShopObject = new ShopObject(_name, _type);
        //Debug.Log("############### Start");
        Debug.Log("############### ShopObject - " + ShopObject.Name);
        Debug.Log("############### CurrentObject - " + GM.Gm.CurrentObject.Name);
        if (ShopObject.Equals(GM.Gm.CurrentObject))
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
    void Update() { }

    /// <summary>
    /// Evento cuando se clicka el objeto.
    /// </summary>
    private void OnMouseDown()
    {
        StartPoint = transform.position;
        Offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, OFFSET_Z));
    }

    /// <summary>
    /// Evento cuando se mantiene pulsado el objeto.
    /// </summary>
    private void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, OFFSET_Z);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + Offset;
        transform.position = new Vector3(transform.position.x, transform.position.y, -5);
    }

    /// <summary>
    /// Evento cuando se deja de clickar el objeto.
    /// </summary>
    private void OnMouseUp()
    {
        if (ItsInTarget)
        {
            Target target = Collision.gameObject.GetComponent<Target>();
            if (target.Type.Equals(ShopObject.ShopType))
                GM.Gm.CorrectShop(ShopObject);
            else
                GM.Gm.WrongShop(ShopObject);

            try
            {
                GM.Gm.NextObject();
                LevelManager.EnabledNextObjectGame();
            }
            catch (Exception) {
                GM.Gm.PutResult();
                GM.Gm.LoadScene("Result");
            }
        }
        transform.position = StartPoint;
        ItsInTarget = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collision = collision ?? throw new ArgumentNullException(nameof(collision));
        ItsInTarget = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == null)
            throw new ArgumentNullException(nameof(collision));
        ItsInTarget = false;
    }

   private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null)
            ItsInTarget = false;
        else
        {
            ItsInTarget = true;
        }
    }

    #endregion
}