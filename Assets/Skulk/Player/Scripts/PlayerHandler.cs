using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHandler : MonoBehaviour
{
    Camera Camera;

    [NonSerialized]public GameObject Orientation;
    [NonSerialized] public Vector3 OrientationX;
    [NonSerialized]public Vector3 OrientationY;
    GameObject Player;
    GameObject PlayerModel;
    public bool Grounded;

    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;


        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform LocalOrientation = gameObject.transform.GetChild(i);
            if (LocalOrientation.name == "Orientation")
            {
                Orientation = LocalOrientation.gameObject;
            }
        }

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform LocalPlayerModel = gameObject.transform.GetChild(i);
            if (LocalPlayerModel.name == "PlayerModel")
            {
                PlayerModel = LocalPlayerModel.gameObject;
            }
        }

        Player = gameObject;
        this.Camera = gameObject.GetComponent<Camera>();

        if (Camera.FirstPersonCamera != null && Player != null && Orientation != null && PlayerModel != null)
        {
            Debug.Log("Succesfully got all components for (PlayerHandler.cs)");
        }
        else
        {
            Debug.LogWarning("Unsuccesfull with gathering components for (PlayerHandler.cs)");
        }

        
    }
    void Update()
    {
        Orientation.transform.eulerAngles = Camera.CameraRotation();
        OrientationX = Orientation.transform.forward;
        OrientationX.y = 0;
        OrientationX.Normalize();
        OrientationY = Orientation.transform.forward;
        OrientationY.x = 0;
        OrientationY.Normalize();

        Ray GroundCheck = new Ray(PlayerModel.transform.position, -PlayerModel.transform.up);
        Grounded = Physics.Raycast(GroundCheck, 1.2f);
        
    }
}
