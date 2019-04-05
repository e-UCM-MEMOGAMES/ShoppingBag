using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class DraggNDrop : MonoBehaviour
    {
        #region Variables Unity
        [SerializeField]
        private ShopType _shopType;
        [SerializeField]
        private ShopObject _shopObject;
        private GameObject _gameObj;
        #endregion

        #region Constantes
        public ShopType ShopType { get => _shopType; set => _shopType = value; }
        public ShopObject ShopObject { get => _shopObject; set => _shopObject = value; }
        //public GameObject ShopGameObj;
        //public ShopObject ShopObjectPruebas;
        #endregion

        #region Eventos
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("##### Start");
            Debug.Log("##### ShopObject - " + ShopObject.Name);
            if (ShopObject == GM.Gm.CurrentObject)
            {
                gameObject.SetActive(true);
                Debug.Log("##### Start true");
            }
            else
            {
                gameObject.SetActive(false);
                Debug.Log("##### Start false");
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
                Debug.Log("##### Collision enter");
                if (collision.gameObject.Equals(ShopType))        
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
               if(GM.Gm.ShopList.Count == 0)
                    SceneManager.LoadScene("Result");
            }
        }

        #endregion
    }
}