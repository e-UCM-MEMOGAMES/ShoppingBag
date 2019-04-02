using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    #region Atributos

    #endregion

    #region Eventos

    void Start() { }

    void Update() { }

    #endregion

    #region Métodos públicos

    /// <summary>
    /// Comienza la partida.
    /// </summary>
    public void Play()
    {
        LoadShopList();
        SceneManager.LoadScene("Level1");
    }

    #endregion

    #region Métodos privados

    /// <summary>
    /// Carga la lista de la compra de los recursos.
    /// </summary>
    private void LoadShopList()
    {
        TextAsset list = (TextAsset)Resources.Load(string.Concat("ShopLists/", "Level1"), typeof(TextAsset));
        string txt = Encoding.UTF8.GetString(list.bytes);
        GM.Gm.ShopList = new List<string>(txt.Split(new[] { "\r\n", "\r", "\n", "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()));
    }

    #endregion

}
