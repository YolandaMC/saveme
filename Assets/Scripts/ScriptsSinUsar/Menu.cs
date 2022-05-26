using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame() //para el botón que me permita ir a la escena de juego
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() //para salir por completo de la aplicacion
    {
        Application.Quit();
    }


    // [SerializeField] GameObject UINuevoJuego; //public GameObject UINuevoJuego;
    // [SerializeField] GameObject UIGameplay; //public GameObject UIGameplay;

    // [SerializeField] Manager Estado; //public Manager Estado;

    // public void btnNuevoJuego (){
    //     //UINuevoJuego.SetActive(false);
    //     //UIGameplay.SetActive(true);
    //     //Estado.STATE_MACHINE = "PLAY";
    // }
}
