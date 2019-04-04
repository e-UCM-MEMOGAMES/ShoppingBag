using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
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

        /// <summary>
        /// Mensaje si han acertado o fallado todos los objetos.
        /// </summary>
        public Text All { get => _all; set => _all = value; }

        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
