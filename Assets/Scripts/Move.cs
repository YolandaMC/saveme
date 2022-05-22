using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour //esa clase creada llamada Move tiene que llamarse exactamente igual que el fichero (incluido mayúsculas y minúsculas)
{
    [SerializeField]
    Vector3 velocidad;
    //public Vector3 velocidad; //variable vector velocidad para el desplazamiento
    //hago este atributo publico por C# por defecto los hace privados y lo necesito público para poder acceder a él desde unity

    [SerializeField]
    float velRotation;


    // Start is called before the first frame update
    void Start()
    {
        //velocidad = new Vector3(1.0f, 2.0f, 3.0f); //he creado una velocidad que yo consigo que modifique la velocidad pero no me ayuda a que no siga dando saltos el programa
        //el programa da saltos por el numero de fotogramas y cada dispositivo trabaja a unos fotogramas luego necesito multiplicar la velocidad por un atributo que me regule
        //esos fotogramas por vuelta/loop/update. Para ello uso deltaTime
        //ahora me doy cuenta que con esta velocidad establecida el desplazamiento es muy lento. Para no tener que estar modificando codigo constantemente voy a hacer este atributo
        //público, es decir, que lo pueda modificar desde unity (modificado en tiempo de ejecuión), pero cuidado luego sí tienes que ponerlo definitivo en el archivo script, lo otro solo es de testeo
        //por último comento el new o inicialización de la velocidad porque lo he hehco modificable desde la interfaz (y asi no tengo que venir aquí)
        //ahora hay otra cuestión, hacer publicos atributos puede dar error, entonces unity da otra opción a hacerlo público, SerializeField permite que sea privado pero el desarrollador
        //lo modifique desde la interfaz de unity
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal")));
        //quiero que la velocidad a la que me voy a desplazar sea constante independientemente del dispositivo donde ejecute (), para ello uso time.deltaTime
        transform.Translate (new Vector3(Input.GetAxis("Vertical") * velocidad.z * Time.deltaTime, 
                                        0.0f, 
                                        Input.GetAxis("Horizontal") * velocidad.x * Time.deltaTime));
        //(para el ejercicio del sol) Primero hacemos una traslación y luego una rotación en el up del vector 3
        transform.Rotate (Vector3.up * velRotation * Time.deltaTime);
    }
}
