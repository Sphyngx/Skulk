using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameObject Player;
    CharacterController Controller;
    PlayerHandler PlayerHandler;

    [SerializeField] float MoveSpeed;
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
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 MoveDirection = (PlayerHandler.Orientation.transform.forward * vertical + PlayerHandler.Orientation.transform.right * Horizontal).normalized;

        Controller.SimpleMove(MoveDirection * MoveSpeed);

        //Add jump logic
        
            if (Input.GetKeyDown(KeyCode.Space) && PlayerHandler.Grounded)
            {
                Vector3 Velocity = new Vector3(0, JumpPower, 0);
                Controller.SimpleMove(Velocity * Time.deltaTime); 
            }
        
    }
}
