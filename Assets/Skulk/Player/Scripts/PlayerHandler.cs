using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHandler : MonoBehaviour
{
    Camera Camera;
    CameraLookAt CameraLookAt;

    [NonSerialized]public GameObject Orientation;
    [NonSerialized]public Vector3 OrientationX;
    [NonSerialized]public Vector3 OrientationY;
    GameObject Player;
    [SerializeField]GameObject PlayerModel;
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
        CameraLookAt = gameObject.GetComponent<CameraLookAt>();

        if (Player != null && Orientation != null && PlayerModel != null)
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
        if (CameraLookAt.UserLookAt)
        {
            Orientation.transform.forward = CameraLookAt.LookAtTarget(CameraLookAt.UserLookAt, CameraLookAt.ScriptedLookAt);
            OrientationX = Orientation.transform.forward;
            OrientationX.y = 0;
            OrientationX.Normalize();
            OrientationY = Orientation.transform.forward;
            OrientationY.x = 0;
            OrientationY.Normalize();

            PlayerModel.transform.forward = OrientationX;
        }
        else
        {
            Orientation.transform.eulerAngles = Camera.CameraRotation(new Vector3(0, 0, 0));
            OrientationX = Orientation.transform.forward;
            OrientationX.y = 0;
            OrientationX.Normalize();
            OrientationY = Orientation.transform.forward;
            OrientationY.x = 0;
            OrientationY.Normalize();

            PlayerModel.transform.forward = OrientationX;
        }

        //Ray GroundCheck = new Ray(PlayerModel.transform.position, -PlayerModel.transform.up);
        //Grounded = Physics.Raycast(GroundCheck, 1.2f);
        
    }
}
