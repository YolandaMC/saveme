using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusObject : MonoBehaviour   
{

    public GameObject Portal; //creo una variable con mi objeto portal que finaliza el juego (para volver a comenzar en bucle)

    void OnCollisionEnter (Collision collision){

        if(collision.gameObject.tag == "Player"){// si el elemento que colisiona con el StatusObject es el jugador entonces se podrá acceder al portal que finaliza el juego
            //Destroy(this.gameObject);
            //función que permita que cuando el jugador colisione con el Portal el juego finalice (es decir vuelva a comenzar)
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
