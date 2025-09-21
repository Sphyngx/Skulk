using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEventReciever : MonoBehaviour
{
    public HumanoidCombat HumanoidCombat_;

    
    private void OnTriggerEnter(Collider Hit)
    {
        Debug.Log(Hit.gameObject.name);
        Status Status_ = Hit.gameObject.GetComponent<Status>();
        if (Status_ != null)
        {
            Status_.DealDamage(HumanoidCombat_.Damage);
        }
    }
}
