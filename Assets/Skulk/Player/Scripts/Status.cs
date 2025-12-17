using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField]HumanoidCombat HumanoidCombat;
    [SerializeField]int Health;
    [SerializeField]int Posture;
    [SerializeField] ParticleSystem[] ParryParticles;
    
    private void Start()
    {
        HumanoidCombat = gameObject.GetComponent<HumanoidCombat>();

        if (HumanoidCombat != null)
        {
            Debug.Log("Succesfully got all components for (Status.cs)");
        }
        else
        {
            Debug.LogWarning("Unsuccesfull with gathering components for (Status.cs)");
            if (HumanoidCombat == null)
            {
                Debug.LogWarning(gameObject + " does not have a Combat script");
            }
        }
    }
    public void DealDamage(int damage)
    {
        if (HumanoidCombat.IsParry)
        {
            Debug.Log(gameObject + " Parried an attack");
            HumanoidCombat.Animator.SetTrigger("ParryTrigger");
            for (int i = 0; i < ParryParticles.Length; i++)
            {
                ParryParticles[i].Play();
            }
        }
        else if (HumanoidCombat.IsBlocking)
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
                Destroy(gameObject);
            }
        }
    }
}

