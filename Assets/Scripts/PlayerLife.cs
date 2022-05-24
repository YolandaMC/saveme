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
    public float roundTimer; // variable to save the number

    private void Update() //checks every frame
    {
        //Timer
        roundTimer = roundTimer - Time.deltaTime; //-deltaTime so that the counter goes down
        int roundTimerInt = (int)roundTimer; //changes a float into an int
        timerText.text = roundTimerInt.ToString();

        if (roundTimer <= 0f) //time is over, under 0
        {
            Debug.Log("Time over.");
            Die();
        }

        //Dying
        if (transform.position.y < -1f && !dead) //y position is under -1 & dead is false
        {
            GetComponent<MeshRenderer>().enabled = false; //shuts down Mesh Renderer
            GetComponent<Rigidbody>().isKinematic = true; //Player cant be moved my objects anymore
            GetComponent<Move>().enabled = false; //shuts down Move Script

            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body")) //if you collide with the tag //still missing!
        {
            Die();
        }
    }
    void Die()
    {
        Invoke(nameof(ReloadLevel), 1.3f); // just ReloadLevel(); wihtout delay is too fast
        dead = true;
        deathSound.Play();
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
