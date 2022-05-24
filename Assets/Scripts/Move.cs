using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour //esa clase creada llamada Move tiene que llamarse exactamente igual que el fichero (incluido may�sculas y min�sculas)
{
    Rigidbody rb;
    [SerializeField] Transform groundCheck; 
    [SerializeField] LayerMask ground;

    [SerializeField] float movementSpeed = 6f; //movement speed
    [SerializeField] float jumpForce = 5f; //jump force

    [SerializeField] AudioSource jumpSound; // jump sound

    [SerializeField]
    Vector3 velocidad;
    //public Vector3 velocidad; //variable vector velocidad para el desplazamiento
    //hago este atributo publico por C# por defecto los hace privados y lo necesito p�blico para poder acceder a �l desde unity

    [SerializeField]
    float velRotation;


    // Start is called before the first frame update
    void Start()
    {
        //velocidad = new Vector3(1.0f, 2.0f, 3.0f); //he creado una velocidad que yo consigo que modifique la velocidad pero no me ayuda a que no siga dando saltos el programa
        //el programa da saltos por el numero de fotogramas y cada dispositivo trabaja a unos fotogramas luego necesito multiplicar la velocidad por un atributo que me regule
        //esos fotogramas por vuelta/loop/update. Para ello uso deltaTime
        //ahora me doy cuenta que con esta velocidad establecida el desplazamiento es muy lento. Para no tener que estar modificando codigo constantemente voy a hacer este atributo
        //p�blico, es decir, que lo pueda modificar desde unity (modificado en tiempo de ejecuion), pero cuidado luego si tienes que ponerlo definitivo en el archivo script, lo otro solo es de testeo
        //por ultimo comento el new o inicializacion de la velocidad porque lo he hehco modificable desde la interfaz (y asi no tengo que venir aqui)
        //ahora hay otra cuestion, hacer publicos atributos puede dar error, entonces unity da otra opcion a hacerlo publico, SerializeField permite que sea privado pero el desarrollador
        //lo modifique desde la interfaz de unity

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        //transform.Translate(new Vector3(Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal")));
        //quiero que la velocidad a la que me voy a desplazar sea constante independientemente del dispositivo donde ejecute (), para ello uso time.deltaTime
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal") * velocidad.z * Time.deltaTime,
                                       //0.0f,
                                       // Input.GetAxis("Vertical") * velocidad.x * Time.deltaTime));
        //(para el ejercicio del sol) Primero hacemos una traslacion y luego una rotacion en el up del vector 3
        //transform.Rotate(Vector3.up * velRotation * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && IsGrounded()) //jump-button pressed & methode is true? --> just jumps when you touch the ground
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    bool IsGrounded() //checks if CheckSphere is true --> if Ground Check object overlaps with Ground --> just when Player is on the ground
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
