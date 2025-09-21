using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField]int Health;
    [SerializeField]int Posture;

    bool DealPostureDamage = false;

    public void DealDamage(int damage)
    {
        if (DealPostureDamage)
        {
            Posture -= damage;
            if (Posture <= 0)
            {
                Debug.Log(gameObject.name + " was guardbroken!");
                Health -= damage + Posture;
            }
        }
        else
        {
            Health -= damage;
            if (Health <= 0)
            {
                Debug.Log(gameObject.name + " has died!");
            }
        }
    }
}

