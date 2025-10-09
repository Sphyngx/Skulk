using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class HumanoidCombat : MonoBehaviour
{
    GameObject ScriptOwner;
    GameObject Orientation;
    public GameObject Weapon;
    public Animator Animator;
    [SerializeField] WeaponEventReciever WeaponEventReciever_;
    public bool IsBlocking;
    public bool IsParry;
    public bool IsSwinging;
    public Collider ParryHitbox;

    public int Damage;
    void Start()
    {
        ScriptOwner = gameObject;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform LocalOrientation = gameObject.transform.GetChild(i);
            if (LocalOrientation.name == "Orientation")
            {
                Orientation = LocalOrientation.gameObject;
            }
        }
        if (ScriptOwner != null && Orientation != null && Animator != null && WeaponEventReciever_ != null)
        {
            Debug.Log("Succesfully got all components for (HumanoidCombat.cs)");
        }
        else
        {
            Debug.LogWarning("Unsuccesfull with gathering components for (HumanoidCombat.cs)");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MeleeM1();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Block();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            IsBlocking = false;
            Animator.SetBool("BlockBool", false);
        }
    }

    public void MeleeM1()
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("IdleState"))
        {
            Animator.SetTrigger("M1Trigger");
        }
    }
    public void MeleeM2()
    {

    }
    public void Block()
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("IdleState"))
        {
            Animator.SetTrigger("ParryWindowTrigger");
            Animator.SetBool("BlockBool", true);
            ParryHitbox.enabled = true;
            IsParry = true;
            IsBlocking = true;
        }
    }
    public void EndParryWindow()
    {
        ParryHitbox.enabled = false;
        IsParry = false;
    }
}
