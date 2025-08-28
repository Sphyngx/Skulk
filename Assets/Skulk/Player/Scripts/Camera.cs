using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cinemachine;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float MouseX;
    float MouseY;

    float RotationX;
    float RotationY;

    GameObject Player;
    GameObject LookAt;
    [NonSerialized] public GameObject FirstPersonCamera;
    [SerializeField] GameObject FirstPersonCamLocation;
    [SerializeField] float ZoomSpeed;
    [SerializeField] float Sensetivity;
    [SerializeField] Vector3 Offsett;
    private void Start()
    {
        FirstPersonCamera = GameObject.FindGameObjectWithTag("1stPersonCamera");
        if (FirstPersonCamera != null)
    
        {
            Debug.Log("Succesfully got all components for (Camera.cs)");
        }
        else
        {
            Debug.LogWarning("Unsuccesfull with gathering components for (Camera.cs)");
        }
    }
    void Update()
    {
        FirstPersonCamera.transform.position = FirstPersonCamLocation.transform.position;
        FirstPersonCamera.transform.eulerAngles = CameraRotation();
    }

    public Vector3 CameraRotation()
    {
        MouseX = Input.GetAxisRaw("Mouse X");
        MouseY = Input.GetAxisRaw("Mouse Y");

        RotationX += MouseX * Sensetivity;
        RotationY -= MouseY * Sensetivity;

        RotationY = Mathf.Clamp(RotationY, -90, 90);

        return new Vector3(RotationY, RotationX, 0);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject[] LookAt_Array = GameObject.FindGameObjectsWithTag("LookAt");
            float Distance = Vector3.Distance(Player.transform.position, LookAt_Array[0].gameObject.transform.position);
            for (int i = 0; i < LookAt_Array.Length; i++)
            {
                if (Vector3.Distance(Player.transform.position, LookAt_Array[i].gameObject.transform.position) < Distance)
                {
                    Distance = Vector3.Distance(Player.transform.position, LookAt_Array[i].gameObject.transform.position);
                    LookAt = LookAt_Array[i].gameObject;
                }
            }
        
        }
    }
}
