using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class AIEyes : MonoBehaviour
{
    public GameObject Player;
    public bool SeeingPlayer;
    [SerializeField] float VisionRange;
    [SerializeField] float VisionAngle;

    [SerializeField] bool showDebug = false;
    private void Update()
    {
       if (Vector3.Distance(gameObject.transform.position,Player.transform.position) < VisionRange)
        {
            SeeingPlayer = Look();
        }
        else
        {
            SeeingPlayer = false;
        }
       if (SeeingPlayer) //LookAt PLayer
        {
            transform.rotation = Quaternion.LookRotation(Player.transform.position - gameObject.transform.position,gameObject.transform.up);
        }
    }
    bool Look()
    {
        if (!Physics.Linecast(gameObject.transform.position, Player.transform.position,1 << 7))
        {
            float AngleToPlayer = Vector3.Angle(gameObject.transform.forward, Player.transform.position - gameObject.transform.position);
            if (AngleToPlayer <  VisionAngle)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        if (!showDebug) return;

        if (SeeingPlayer) 
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(gameObject.transform.position, Player.transform.position);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(gameObject.transform.position, Player.transform.position);
        }

    }
   
}


