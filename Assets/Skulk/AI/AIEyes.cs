using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AIEyes : MonoBehaviour
{
    public GameObject Player;
    public bool SeeingPlayer;
    [SerializeField] float VisionRange;
    [SerializeField] float VisionAngle;
    private void Update()
    {
       if (Vector3.Distance(gameObject.transform.position,Player.transform.position) < VisionRange)
        {
            Look();
        }
        else
        {
            SeeingPlayer = false;
        }
    }
    bool Look()
    {
        if (!Physics.Linecast(gameObject.transform.position, Player.transform.position,1 << 7))
        {
            if (Mathf.Asin(Player.transform.position.z/Vector3.Distance(gameObject.transform.position,Player.transform.position)) / Mathf.PI * 180 > VisionAngle)
            {
                SeeingPlayer = true;
            }
            else
            {
                SeeingPlayer = false;
            }
        }
        else
        {
            SeeingPlayer = false;
        }
            return SeeingPlayer;
    }

    private void OnDrawGizmos()
    {
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


