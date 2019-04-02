using System.Collections.Generic;
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
    public List<string> ShopList { get; set; } = new List<string>();

    /// <summary>
    /// Nombre del objeto de la lista actual.
    /// </summary>
    public string CurrentObject { get; set; }

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

    #endregion

}