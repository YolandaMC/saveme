using UnityEngine;

[RequireComponent(typeof(InputController))] //comprobacíon para evitar errores que vengan del script InputController

public class CharacterController : MonoBehaviour
{
    [SerializeField] float _speed = 0f; //variable privada no accesible desde otro script
    [SerializeField] float _rotationSpeed = 0f; //variable privada no accesible desde otro script

    InputController _inputController = null;

    void Awake()
    {
        _inputController = GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //llamamos al metodo de movimiento y se actualiza en cada frame
    }

    void Move() //generamos un metodo para traer los datos de movimiento y mover el personaje
    {
        Vector2 input = _inputController.MoveInput();

        transform.position += transform.forward * input.y * _speed * Time.deltaTime;
        transform.Rotate(Vector3.up * input.x * _rotationSpeed * Time.deltaTime);
    }
}
