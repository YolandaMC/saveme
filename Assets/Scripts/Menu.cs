using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject UINuevoJuego; //public GameObject UINuevoJuego;
    [SerializeField] GameObject UIGameplay; //public GameObject UIGameplay;

    [SerializeField] Manager Estado; //public Manager Estado;

    public void btnNuevoJuego (){
        //UINuevoJuego.SetActive(false);
        //UIGameplay.SetActive(true);
        //Estado.STATE_MACHINE = "PLAY";
    }
}
