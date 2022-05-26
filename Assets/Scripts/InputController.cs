using UnityEngine;

public class InputController : MonoBehaviour
{
  public Vector2 MoveInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        return new Vector2(x, y);
    }
}
