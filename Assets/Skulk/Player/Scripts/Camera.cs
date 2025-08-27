using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject Player;
    GameObject LookAt;
    [SerializeField] GameObject VirtualCamera;
    [SerializeField] float ZoomSpeed;
    
    private void Start()
    {
        Player = gameObject;
        if (VirtualCamera != null && Player != null)
        {
            Debug.Log("Succesfully got all components for (Camera.cs)");
        }
        else
        {
            Debug.LogWarning("Unsuccesfull with gathering components for (Camera.cs)");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject[] LookAt_Array = GameObject.FindGameObjectsWithTag("LookAt");
            float Distance = Vector3.Distance(Player.transform.position, LookAt_Array[0].gameObject.transform.position);
            for (int i = 0; i < LookAt_Array.Length; i++)
            {
                if (Vector3.Distance(Player.transform.position, LookAt_Array[i].gameObject.transform.position) < Distance)
                {
                    Distance = Vector3.Distance(Player.transform.position, LookAt_Array[i].gameObject.transform.position);
                    LookAt = LookAt_Array[i].gameObject;
                }
            }
        
        }
    }
}
