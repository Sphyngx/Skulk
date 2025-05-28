using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject VirtualCamera;
    CinemachineFreeLook FreeLook;
    CinemachineFreeLook.Orbit[] NewOrbits;
    [SerializeField] float ZoomSpeed;
    private void Start()
    {
        FreeLook = VirtualCamera.GetComponent<CinemachineFreeLook>();
        NewOrbits = new CinemachineFreeLook.Orbit[FreeLook.m_Orbits.Length];
        if (VirtualCamera != null && FreeLook != null && NewOrbits != null)
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
        for (int i = 0;i < FreeLook.m_Orbits.Length; i++)
        {
            FreeLook.m_Orbits[i].m_Radius -= Input.mouseScrollDelta.y;
            //if (FreeLook.m_Orbits[i].m_Radius < NewOrbits[i].m_Radius)
            //{
            //    float Timer = Time.deltaTime * ZoomSpeed;
            //    FreeLook.m_Orbits[i].m_Radius += Mathf.Lerp(FreeLook.m_Orbits[i].m_Radius, NewOrbits[i].m_Radius, Timer);
            //}
        }
    }
}
