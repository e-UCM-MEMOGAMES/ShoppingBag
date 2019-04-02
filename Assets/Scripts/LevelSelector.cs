using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
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
            TextAsset textlist = (TextAsset)Resources.Load(string.Concat("ShopLists/", "Level1"));
            string txt = Encoding.UTF7.GetString(textlist.bytes);
            List<string> list = new List<string>(txt.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()));

            // La lista estará formada por líneas de tipo -> {nombre del objeto}, {nombre de la tienda}
            list.ForEach(obj =>
            {
                List<string> listObj = new List<string>(obj.Split(',').Select(o => o.Trim()));
                if (listObj.Count == 2)
                {
                    GM.Gm.ShopList.Add(new ShopObject(listObj[0], GetShopType(listObj[1])));
                }
            });

            GM.Gm.CurrentObject = GM.Gm.ShopList.First();
        }

        /// <summary>
        /// Determina el tipo de tienda según el nombre.
        /// </summary>
        /// <param name="type">Nombre de la tienda.</param>
        /// <returns>Tipo de la tienda.</returns>
        private ShopType GetShopType(string type)
        {
            switch (type.ToUpper())
            {
                case "CARNICERIA":
                case "CARNICERÍA":
                    return ShopType.CARNICERIA;
                case "ELECTRODOMESTICOS":
                case "ELECTRODOMÉSTICOS":
                    return ShopType.ELECTRODOMESTICOS;
                case "FARMACIA":
                    return ShopType.FARMACIA;
                case "PANADERIA":
                case "PANADERÍA":
                    return ShopType.PANADERIA;
                case "FRUTERIA":
                case "FRUTERÍA":
                    return ShopType.FRUTERIA;
                case "PASTELERIA":
                case "PASTELERÍA":
                    return ShopType.PASTELERIA;
                default:
                    return ShopType.PESCADERIA;
            }
        }

        #endregion

    }
}
