using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject pan;
    public GameObject titulopan;
    public GameObject play;
    public GameObject[] bocadillo;

    int paso;
    // Start is called before the first frame update
    void Start()
    {
        paso = 0;
        bocadillo[0].SetActive(true);
        pan.SetActive(false);
        titulopan.SetActive(false);
    }

    public void setInfo()
    {
        if (paso == 0)
        {
            //Debug.Log("############ paso 1");
            bocadillo[0].SetActive(false);
            bocadillo[1].SetActive(true);
            paso++;
        }
        else if (paso == 1)
        {
            //Debug.Log("############ paso 2");
            bocadillo[1].SetActive(false);
            bocadillo[2].SetActive(true);
            paso++;
        }
        else if (paso == 2)
        {
            //Debug.Log("############ paso 3");
            bocadillo[2].SetActive(false);
            bocadillo[3].SetActive(true);
            pan.SetActive(true);
            titulopan.SetActive(true);
            play.SetActive(false);
        }
    }
}
