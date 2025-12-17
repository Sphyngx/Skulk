using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEventReciever : MonoBehaviour
{
    public HumanoidCombat HumanoidCombat;
    
    private void OnTriggerEnter(Collider Hit)
    {
        Debug.Log(Hit.gameObject.name);
        Status OponentStatus = Hit.gameObject.GetComponent<Status>();
        if (OponentStatus != null)
        {
            OponentStatus.DealDamage(HumanoidCombat.Damage);    
        }
    }
    public void EndParryWindow()
    {
        HumanoidCombat.EndParryWindow();
    }
}
