using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //to reload the level
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSound; //death sound
    bool dead = false; // variable, so that Die() isnt called always

    //public Text timerText; //variable for timer textfield
    //public float roundTimer; // variable to save the number

    private void Update() //checks every frame
    {
        //Timer
        //roundTimer = roundTimer - Time.deltaTime; //-deltaTime so that the counter goes down
        //int roundTimerInt = (int)roundTimer; //changes a float into an int
        //timerText.text = roundTimerInt.ToString();

        //Dying //if (transform.position.y < -40f && !dead || roundTimer <= 0f)
        if (transform.position.y < -40f && !dead) //y position is under -1 & dead is false, or: timer is <=0
        {
            GetComponent<MeshRenderer>().enabled = false; //shuts down Mesh Renderer
            GetComponent<Rigidbody>().isKinematic = true; //Player cant be moved my objects anymore
            //GetComponent<CharacterController>().enabled = false; //shuts down Move Script

            Debug.Log("Game over.");

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
