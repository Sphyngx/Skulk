using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TestHandler : MonoBehaviour
{
    public GameObject Camera;

    GameObject Box;
    float MouseX;
    float MouseY;

    float RotationX;
    float RotationY;
    void Start()
    {
        Box = gameObject;

        RotationX = Box.transform.eulerAngles.x;
        RotationY = Box.transform.eulerAngles.y;
    }

    
    void Update()
    {
        MouseX = Input.GetAxisRaw("Mouse X");
        MouseY = Input.GetAxisRaw("Mouse Y");
     
        RotationX -= MouseX;
        RotationY -= MouseY;

        
        RotationY = Mathf.Clamp(RotationY, -90, 90);

        //Box.transform.eulerAngles = new Vector3(RotationY, RotationX, 0);
        //Box.transform.eulerAngles = new Vector3(RotationY, RotationX, 0);

        Box.transform.eulerAngles = new Vector3(RotationY, Camera.transform.eulerAngles.y, 0);
    }
}
