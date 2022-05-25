using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move: MonoBehaviour //esa clase creada llamada Move tiene que llamarse exactamente igual que el fichero (incluido may�sculas y min�sculas)
{
    Rigidbody rb;
    [SerializeField] Transform groundCheck; 
    [SerializeField] LayerMask ground;

    [SerializeField] float movementSpeed = 200f; //movement speed
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] float jumpForce = 5f; //jump force
    [SerializeField] public Animator anim;

    [SerializeField] AudioSource jumpSound; // jump sound

    //[SerializeField] Vector3 velocidad; //variable vector velocidad para el desplazamiento



    // Start is called before the first frame update
    void Start()
    {
        
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");

        //transform.Rotate(0, horizontalInput*Time.deltaTime*rotationSpeed, 0); //esta funcion hace que el personaje rote
        //transform.Translate(new Vector3(horizontalInput, 0f, verticalInput));

        anim.SetFloat("VelX", horizontalInput);
        anim.SetFloat("VelY", verticalInput);
        rb.velocity = new Vector3(horizontalInput* movementSpeed, 0f, verticalInput * movementSpeed);
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
