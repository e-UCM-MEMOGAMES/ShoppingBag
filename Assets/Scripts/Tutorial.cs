using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RAGE.Analytics;
public class Tutorial : MonoBehaviour
{
    public GameObject pan;
    public GameObject titulopan;
    public GameObject play;
    public Text textTutorial;

    int paso;
    // Start is called before the first frame update
    void Start()
    {
        paso = 0;
        Tracker.T.setVar("TutorialStep", paso);
        textTutorial.text = "Hoy tendrá que ser capaz de encontrar el lugar donde venden pan";
        pan.SetActive(false);
        titulopan.SetActive(false);
        
    }

    public void setInfo()
    {
        if (paso == 0)
        {
            //Debug.Log("############ paso 1");
            Tracker.T.setVar("TutorialStep", paso + 1);
            textTutorial.text = "Para ello, necesitará encontrar la panadería";
            paso++;
        }
        else if (paso == 1)
        {
            //Debug.Log("############ paso 2");
            Tracker.T.setVar("TutorialStep", paso + 1);
            textTutorial.text = "Cuando la encuentre, deberá arrastrar el pan al edificio";
            paso++;
        }
        else if (paso == 2)
        {
            //Debug.Log("############ paso 3");
            Tracker.T.setVar("TutorialStep", paso + 1);
            textTutorial.text = "Consejo: mantener pulsado el objeto para poder desplazarlo a su tienda";
            pan.SetActive(true);
            titulopan.SetActive(true);
            play.SetActive(false);
        }
    }
}
