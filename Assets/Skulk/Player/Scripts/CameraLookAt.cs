using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    GameObject LookAt;
    [SerializeField] GameObject CameraHolder;
    [SerializeField] float LookAtRadius;
    [SerializeField] LayerMask LookAtLayerMask;
    public bool ScriptedLookAt = false;
    public bool UserLookAt = false;
    [NonSerialized] public GameObject FirstPersonCamera;
    // Start is called before the first frame update
    void Start()
    {
        FirstPersonCamera = GameObject.FindGameObjectWithTag("1stPersonCamera");
        if (FirstPersonCamera != null)

        {
            Debug.Log("Succesfully got all components for (CameraLookAt.cs)");
        }
        else
        {
            Debug.LogWarning("Unsuccesfull with gathering components for (CameraLookAt.cs)");
        }
    }

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) && !UserLookAt && !ScriptedLookAt)
        {
            if (FindLookAtTarget())
            {
                UserLookAt = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && UserLookAt && !ScriptedLookAt)
        {
            LookAt = null;
            UserLookAt = false;
        }

        if (UserLookAt)
        {
            FirstPersonCamera.transform.rotation = Quaternion.LookRotation(LookAtTarget(UserLookAt, ScriptedLookAt), Vector3.up);
        }
    }
    private bool FindLookAtTarget()
    {
        Collider[] LookAt_Array = Physics.OverlapSphere(gameObject.transform.position, LookAtRadius, LookAtLayerMask);
        float Distance = float.MaxValue;
        for (int i = 0; i < LookAt_Array.Length; i++)
        {
            if (Vector3.Distance(gameObject.transform.position, LookAt_Array[i].gameObject.transform.position) < Distance)
            {
                Distance = Vector3.Distance(gameObject.transform.position, LookAt_Array[i].gameObject.transform.position);
                LookAt = LookAt_Array[i].gameObject;
            }
        }
        if (LookAt == null)
        {
            return false;
        }
        Debug.Log("new LookAt!: " + LookAt.gameObject.name);
        return true;
    }

    public Vector3 LookAtTarget(bool LookAt_Bool, bool ScriptedLookAt)
    {
        if (LookAt_Bool)
        {
            return (LookAt.transform.position - FirstPersonCamera.transform.position).normalized;
        }
        return Vector3.zero;
    } 
}
