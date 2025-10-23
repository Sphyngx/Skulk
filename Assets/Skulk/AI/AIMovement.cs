using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] CharacterController Controller;
    [SerializeField] AIBrain AiBrain;
    [SerializeField] float MoveSpeed;
    void Update()
    {
        Vector3 MoveDirection = AiBrain.Destination - gameObject.transform.position;
            Controller.SimpleMove(MoveDirection.normalized * MoveSpeed);
    }
}
