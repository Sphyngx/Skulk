using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameObject Player;
    CharacterController Controller;
    PlayerHandler PlayerHandler;

    [SerializeField] float PlayerMoveSpeed;
    [SerializeField] float JumpPower;

    private void Start()
    {
        Player = gameObject;
        Controller = gameObject.GetComponent<CharacterController>();
        this.PlayerHandler = gameObject.GetComponent<PlayerHandler>();
        
        if (Player != null && Controller != null && PlayerHandler != null)
        {
            Debug.Log("Succesfully got all components for (Movement.cs)");
        }
        else
        {
            Debug.LogWarning("Unsuccesfull with gathering components for (Movement.cs)");
        }
    }
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        float Yaw = PlayerHandler.Orientation.transform.eulerAngles.y;
        Quaternion YawRotation = Quaternion.Euler(0, Yaw, 0);

        Vector3 MoveDirection = YawRotation * new Vector3(Horizontal, 0, Vertical).normalized;

        Controller.SimpleMove(MoveDirection * MoveSpeed);
        
        //Add jump logic?
    }
}