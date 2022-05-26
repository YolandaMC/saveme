using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public List<Collectable> collected;
    public GameObject portal;
    int score = 0;
    [SerializeField] AudioSource collectionSound;
    [SerializeField] AudioSource portalSound;
    [SerializeField] AudioSource finishSound;

    private void OnTriggerEnter(Collider other) //methode to collect the items
    {
        if (other.GetComponent<Collectable>())
        {
            Debug.Log("Collecting: " + other.gameObject.name);
            collected.Add(other.GetComponent<Collectable>());
            other.gameObject.SetActive(false); //makes the object inactive
            score += 25;
            collectionSound.Play();

            if (collected.Count == 4) //if 4 collectables are colleted the portal apears
            {
                Debug.Log("Activate Portal"); //makes the Portal active again, should be inactive before!
                portal.SetActive(true);
                portalSound.Play();
            }
        }
        else if (other.GetComponent<Finish>())
        {
            finishSound.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //se reinicia el juego en la misma escena

        }
    }

}
