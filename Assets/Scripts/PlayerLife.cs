using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //to reload the level
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSound; //death sound
    bool dead = false; // variable, so that Die() isnt called always

    public Text timerText; //variable for timer textfield
    public Text fin;
    [SerializeField] private float roundTimer = 300f; // variable to save the number 

    void Start()
    {
        timerText.text = "" + roundTimer; //inicialización de la variable tiempo
        fin.enabled = false;
    }


    void Update() //checks every frame
    {
        //Timer
        roundTimer -= Time.deltaTime; //-deltaTime so that the counter goes down
        timerText.text = " " + roundTimer.ToString("f0"); //f0 quita la parte flotante al pasar el numero a string

        //Dying //if (transform.position.y < -40f && !dead || roundTimer <= 0f) //if (transform.position.y < -40f && !dead)
        if (transform.position.y < -40f && !dead || roundTimer <= 0f) //y position is under -1 & dead is false, or: timer is <=0
        {
            GetComponent<MeshRenderer>().enabled = false; //shuts down Mesh Renderer
            GetComponent<Rigidbody>().isKinematic = true; //Player cant be moved my objects anymore
            //GetComponent<CharacterController>().enabled = false; //shuts down Move Script

            Debug.Log("Game over.");

            timerText.text = "0";
            fin.enabled = true;

            Die();
        }

    }

    void Die()
    {
        Invoke(nameof(FinishGame), 1.3f); // just FinishGame(); wihtout delay is too fast
        dead = true;
        deathSound.Play();
    }
    void FinishGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(2); //SceneManager.LoadScene("End Screen"); 
        
    }

}
