using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    [SerializeField] float LookAtRadius;
    [SerializeField] LayerMask LookAtLayerMask;
    public bool ScriptedLookAt = false;
    public bool UserLookAt = false;
    [NonSerialized] public GameObject FirstPersonCamera;
    [SerializeField] GameObject FirstPersonCamLocation;
    [SerializeField] float ZoomSpeed;
    [SerializeField] float Sensetivity;
    [SerializeField] Vector3 Offsett;
    private void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.LeftControl) && !UserLookAt && !ScriptedLookAt)
        {
            if (LookAtTarget(UserLookAt, ScriptedLookAt) != Vector3.zero)
            {
                UserLookAt = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && UserLookAt && !ScriptedLookAt)
        {
            LookAt = null;
            UserLookAt = false;
        }

        if (UserLookAt)
        {
            FirstPersonCamera.transform.forward = (LookAtTarget(UserLookAt,ScriptedLookAt));
        }
        else
        {
            FirstPersonCamera.transform.eulerAngles = CameraRotation(new Vector3());
        }
    }

    public Vector3 CameraRotation(Vector3 Direction)
    {
        if (!UserLookAt && !ScriptedLookAt)
        {
            MouseX = Input.GetAxisRaw("Mouse X");
            MouseY = Input.GetAxisRaw("Mouse Y");

            RotationX += MouseX * Sensetivity;
            RotationY -= MouseY * Sensetivity;

            RotationY = Mathf.Clamp(RotationY, -90, 90);

            return new Vector3(RotationY, RotationX, 0);
        }
        else if (UserLookAt && !ScriptedLookAt)
        {
            return Direction;
        }
            return new Vector3();
    }

    private bool FindLookAtTarget()
    {
        Collider[] LookAt_Array = Physics.OverlapSphere(Player.transform.position, LookAtRadius, LookAtLayerMask);
        float Distance = float.MaxValue;
        for (int i = 0; i < LookAt_Array.Length; i++)
        {
            if (Vector3.Distance(Player.transform.position, LookAt_Array[i].gameObject.transform.position) < Distance)
            {
                Distance = Vector3.Distance(Player.transform.position, LookAt_Array[i].gameObject.transform.position);
                LookAt = LookAt_Array[i].gameObject;
            }
        }
        if (LookAt == null)
        {
            return false;
        }
        Debug.Log("new LookAt!: " + LookAt.gameObject.name);
        return true;
    }

    public Vector3 LookAtTarget(bool LookAt_Bool, bool ScriptedLookAt)
    {
        if (!ScriptedLookAt && !LookAt_Bool)
        {
            if (FindLookAtTarget())
            {
                Vector3 Direction = LookAt.transform.position - FirstPersonCamera.transform.position;
                return Direction;
            }
            else
            {
                return Vector3.zero;
            }
        }
        else if (LookAt_Bool && !ScriptedLookAt)
        {
            
                Vector3 Direction = LookAt.transform.position - FirstPersonCamera.transform.position;
                return Direction;
        }
            return new Vector3(0, 0, 0);
    }
}
