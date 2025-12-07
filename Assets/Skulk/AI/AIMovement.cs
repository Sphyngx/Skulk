using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public CharacterController Controller;
    [SerializeField] AIBrain AiBrain;
    void Update()
    {
        if (this.AiBrain.MaxSpeed < this.AiBrain.Steering.magnitude)
        {
            AiBrain.Steering = AiBrain.Steering.normalized * AiBrain.MaxSpeed;
        }
        Controller.SimpleMove(AiBrain.Steering);
    }
}
