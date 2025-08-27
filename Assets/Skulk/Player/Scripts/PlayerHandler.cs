using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHandler : MonoBehaviour
{
    [NonSerialized] public GameObject Orientation;
    GameObject Player;
    GameObject PlayerModel;
    GameObject Camera;

    float MouseX;
    float MouseY;

    float RotationX;
    float RotationY;

    [SerializeField] float Sensitivity;

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

        Camera = GameObject.FindGameObjectWithTag("MainCamera");

        if (Camera != null && Player != null && Orientation != null && PlayerModel != null)
        {
            Debug.Log("Succesfully got all components for (PlayerHandler.cs)");
        }
        else
        {
            Debug.LogWarning("Unsuccesfull with gathering components for (PlayerHandler.cs)");
        }

        RotationY = Orientation.transform.eulerAngles.y;
    }
    void Update()
    {
        //MouseX = Input.GetAxisRaw("Mouse X");
        MouseY = Input.GetAxisRaw("Mouse Y");

        //RotationX -= MouseX;
        RotationY -= MouseY;

        RotationY = Mathf.Clamp(RotationY, -90, 90);

        Orientation.transform.eulerAngles = new Vector3(RotationY, Camera.transform.eulerAngles.y, 0);

        Ray GroundCheck = new Ray(PlayerModel.transform.position, -PlayerModel.transform.up);
        Grounded = Physics.Raycast(GroundCheck, 1.2f);
        
    }
}
