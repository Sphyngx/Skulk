using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    CameraLookAt CameraLookAt;
    float MouseX;
    float MouseY;

    float RotationX;
    float RotationY;

    GameObject Player;
    [NonSerialized] public GameObject FirstPersonCamera;
    [SerializeField] GameObject FirstPersonCamLocation;
    [SerializeField] float Sensetivity;

    [Header("Camera Behaviours")]
    [SerializeField] bool SmoothingBehaviour;
    private void Start()
    {
        CameraLookAt = gameObject.GetComponent<CameraLookAt>();
        FirstPersonCamera = GameObject.FindGameObjectWithTag("1stPersonCamera");
        Player = gameObject;
        if (FirstPersonCamera != null && Player != null && FirstPersonCamLocation != null)
    
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
        if (!CameraLookAt.UserLookAt && !CameraLookAt.ScriptedLookAt)
        {
            FirstPersonCamera.transform.eulerAngles = CameraRotation(new Vector3());
        }

        if (SmoothingBehaviour)
        {
            CameraSmooth();
        }
    }

    public Vector3 CameraRotation(Vector3 Direction)
    {
            MouseX = Input.GetAxisRaw("Mouse X");
            MouseY = Input.GetAxisRaw("Mouse Y");

            RotationX += MouseX * Sensetivity;
            RotationY -= MouseY * Sensetivity;

            RotationY = Mathf.Clamp(RotationY, -90, 90);

            return new Vector3(RotationY, RotationX, 0);
    }

    void CameraSmooth()
    {
        
    }   
}
