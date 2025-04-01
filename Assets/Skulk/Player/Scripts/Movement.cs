using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameObject Player;
    CharacterController Controller;
    [SerializeField] float MoveSpeed;

    private void Start()
    {
        Player = gameObject;
        Controller = gameObject.GetComponent<CharacterController>();
    }
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Controller.SimpleMove(new Vector3(Horizontal * MoveSpeed,0,vertical * MoveSpeed));

        //Add jump logic
    }
}
