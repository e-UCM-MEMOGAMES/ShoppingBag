using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    #region Atributos

    /// <summary>
    /// Manejado general del juego.
    /// </summary>
    public static GM Gm { get; set; }

    /// <summary>
    /// Lista de la compra.
    /// </summary>
    public List<ShopObject> ShopList { get; set; } = new List<ShopObject>();

    /// <summary>
    /// Nombre del objeto de la lista actual.
    /// </summary>
    public ShopObject CurrentObject { get; set; }

    /// <summary>
    /// Lista de objetos seleccionados correctamente.
    /// </summary>
    private List<ShopObject> CorrectList { get; set; } = new List<ShopObject>();

    /// <summary>
    /// Lista de objetos seleccionados erroneamente.
    /// </summary>
    private List<ShopObject> WrongList { get; set; } = new List<ShopObject>();

    #endregion

    #region Eventos

    private void Awake()
    {
        if (Gm == null)
        {
            Gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Gm != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    #endregion

    #region Métodos públicos

    /// <summary>
    /// Carga la siguiente escena.
    /// </summary>
    /// <param name="scene">Nombre de la escena a la que se va a cambiar.</param>
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Método para el botón salir del menú.
    /// </summary>
    public void DoExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Inicializa/Resetea las listas.
    /// </summary>
    public void InitList()
    {
        ShopList.Clear();
        CorrectList.Clear();
        WrongList.Clear();
    }

    /// <summary>
    /// Recoge el siguiente objeto a seleccionar. Si ya no quedan objetos saltará una excepción.
    /// </summary>
    public void NextObject()
    {
        if (ShopList.Count == 0) throw new Exception();

        CurrentObject = new ShopObject(ShopList[0].Name, ShopList[0].ShopType);
        ShopList.RemoveAt(0);
    }

    /// <summary>
    /// Se ha acertado el objeto con su respectiva tienda.
    /// </summary>
    /// <param name="obj">Objeto acertado.</param>
    public void CorrectShop(ShopObject obj)
    {
        CorrectList.Add(obj);
    }

    /// <summary>
    /// Se ha equivocado con el objeto con otra tienda.
    /// </summary>
    /// <param name="obj">Objeto erróneo.</param>
    public void WrongShop(ShopObject obj)
    {
        WrongList.Add(obj);
    }

    public string CorrectListResult()
    {
        if (CorrectList.Count == 0) return null;

        StringBuilder sb = new StringBuilder();
        CorrectList.ForEach(obj =>
        {
            sb.AppendLine(string.Concat("- ", obj.Name));
        });
        return sb.ToString();
    }

    public string WrongListResult()
    {
        if (WrongList.Count == 0) return null;

        StringBuilder sb = new StringBuilder();
        WrongList.ForEach(obj =>
        {
            sb.AppendLine(string.Concat("- ", obj.Name));
        });
        return sb.ToString();
    }

    #endregion

}