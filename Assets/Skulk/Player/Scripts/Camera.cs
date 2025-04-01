using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] float ZoomPercent;
    [SerializeField] GameObject VirtualCamera;
    CinemachineFreeLook FreeLook;
    CinemachineFreeLook.Orbit[] OriginalOrbits;
    private void Start()
    {
        FreeLook = VirtualCamera.GetComponent<CinemachineFreeLook>();
        OriginalOrbits = new CinemachineFreeLook.Orbit[FreeLook.m_Orbits.Length];

        for (int i = 0; i < FreeLook.m_Orbits.Length; i++)
        {
            OriginalOrbits[i].m_Radius = FreeLook.m_Orbits[i].m_Radius;
        }
    }
    void Update()
    {
        ZoomPercent += Mathf.Lerp(ZoomPercent, Input.mouseScrollDelta.y, 2);

        for (int i = 0;i < OriginalOrbits.Length; i++)
        {
            FreeLook.m_Orbits[i].m_Radius = OriginalOrbits[i].m_Radius * ZoomPercent;
        }
    }
}
