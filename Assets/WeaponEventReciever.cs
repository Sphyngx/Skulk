using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEventReciever : MonoBehaviour
{
    public List<Collider> Hits;

    
    private void OnTriggerEnter(Collider Hit)
    {
        Hits.Add(Hit);
    }

}
