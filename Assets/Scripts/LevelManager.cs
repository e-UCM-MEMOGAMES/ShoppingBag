using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _listObjects;


    public List<GameObject> GameShopList { get => _listObjects; set => _listObjects = value; }

    // Start is called before the first frame update
    void Start()  { }

    // Update is called once per frame
    void Update() { }

    public void EnabledNextObjectGame()
    {
        GameShopList.ForEach(obj =>
        {
            ShopObject shopObj = obj.GetComponent<DraggNDrop>().ShopObject;
            if (shopObj.Equals(GM.Gm.CurrentObject))
                obj.SetActive(true);
            else
                obj.SetActive(false);
        });
    }
}
