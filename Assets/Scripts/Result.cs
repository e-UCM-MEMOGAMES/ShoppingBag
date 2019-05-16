using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    #region Variables de Unity

    [SerializeField]
    private Text _correcto;
    [SerializeField]
    private Text _erroneo;
    [SerializeField]
    private Text _correctoList;
    [SerializeField]
    private Text _erroneoList;
    [SerializeField]
    private Text _all;

    [SerializeField]
    private List<Image> _stars;

    #endregion

    #region Atributos

    /// <summary>
    /// Título de los objetos correctos.
    /// </summary>
    public Text CorrectoTitle { get => _correcto; set => _correcto = value; }

    /// <summary>
    /// Título de los objetos erróneos.
    /// </summary>
    public Text ErroneoTitle { get => _erroneo; set => _erroneo = value; }

    /// <summary>
    /// Lista de los objetos correctos.
    /// </summary>
    public Text CorrectoList { get => _correctoList; set => _correctoList = value; }

    /// <summary>
    /// Lista de los objetos erróneos.
    /// </summary>
    public Text ErroneoList { get => _erroneoList; set => _erroneoList = value; }

    public List<Image> Stars { get => _stars; set => _stars = value; }

    /// <summary>
    /// Mensaje si han acertado o fallado todos los objetos.
    /// </summary>
    public Text All { get => _all; set => _all = value; }

    #endregion

    #region Eventos

    void Start()
    {
        string correctList = GM.Gm.CorrectListResult();
        string wrongList = GM.Gm.WrongListResult();

        if (string.IsNullOrWhiteSpace(wrongList))
            PutTextAll("¡Enhorabuena! ¡Acertaste toda la lista de la compra!");
        else if (string.IsNullOrWhiteSpace(correctList))
            PutTextAll("¡Que mal! ¡Fallaste toda la lista de la compra! No te rindas :)");
        else
        {
            CorrectoTitle.enabled = true;
            CorrectoList.enabled = true;
            CorrectoList.text = correctList;
            ErroneoTitle.enabled = true;
            ErroneoList.enabled = true;
            ErroneoList.text = wrongList;
            All.enabled = false;
        }

        int numberStar = PlayerPrefs.GetInt(GM.Gm.Level + "Star");
        for(int i = 0; i < numberStar; ++i)
        {
            Stars[i].color = Color.white;
        }
    }

    #endregion

    #region Métodos privados

    /// <summary>
    /// Se desactiva todos los campos y se pone el mensaje general.
    /// </summary>
    /// <param name="text">Texto a mostrar.</param>
    private void PutTextAll(string text)
    {
        CorrectoTitle.enabled = false;
        CorrectoList.enabled = false;
        ErroneoTitle.enabled = false;
        ErroneoList.enabled = false;
        All.enabled = true;
        All.text = text;
    }

    #endregion

}
