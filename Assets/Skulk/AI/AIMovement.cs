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
        Vector3 MoveDirection = AiBrain.RandomDestination - gameObject.transform.position;
        if (!AiBrain.AtDestination)
        {
            Controller.SimpleMove(MoveDirection.normalized * MoveSpeed);
        }
    }
}
