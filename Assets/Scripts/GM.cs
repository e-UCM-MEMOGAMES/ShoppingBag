using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    #region Atributos

    /// <summary>
    /// Manejado general del juego.
    /// </summary>
    public static GM Gm { get; set; }

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

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /**
     * Método para el botón salir del menú
     */
    public void DoExitGame()
    {
        Application.Quit();
    }

    #endregion

}