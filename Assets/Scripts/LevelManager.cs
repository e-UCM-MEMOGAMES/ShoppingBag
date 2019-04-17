using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _listObjects;

    [SerializeField]
    private Text _title;

    public List<GameObject> GameShopList { get => _listObjects; set => _listObjects = value; }

    public Text Title { get => _title; set => _title = value; }

    // Start is called before the first frame update
    void Start()
    {
        Title.text = GM.Gm.CurrentObject.Name;
    }

    // Update is called once per frame
    void Update() { }

    public void EnabledNextObjectGame()
    {
        GameShopList.ForEach(obj =>
        {
            ShopObject shopObj = obj.GetComponent<DraggNDrop>().ShopObject;
            if (shopObj.Equals(GM.Gm.CurrentObject))
            {
                obj.SetActive(true);
                Title.text = GM.Gm.CurrentObject.Name;
            }
            else
                obj.SetActive(false);
        });
    }
}
