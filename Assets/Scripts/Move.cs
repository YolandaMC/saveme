using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour //esa clase creada llamada Move tiene que llamarse exactamente igual que el fichero (incluido may�sculas y min�sculas)
{
    Rigidbody rb;
    [SerializeField] Transform groundCheck; 
    [SerializeField] LayerMask ground;

    [SerializeField] float movementSpeed = 6f; //movement speed
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] float jumpForce = 5f; //jump force
    private Animator anim;

    [SerializeField] AudioSource jumpSound; // jump sound

    //[SerializeField] Vector3 velocidad; //variable vector velocidad para el desplazamiento

    //[SerializeField] float velRotation;


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
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(0, horizontalInput*Time.deltaTime*rotationSpeed, 0) //esta funcion hace que el personaje rote
        transform.Translate(new Vector3(0.0f, 0.0f, verticalInput * movementSpeed.x * Time.deltaTime));

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        //rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        

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
