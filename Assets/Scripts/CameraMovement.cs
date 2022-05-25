using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerCenter;
    public Transform camPosition;

    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(playerCenter);
        transform.position = camPosition.position;
    }
}
