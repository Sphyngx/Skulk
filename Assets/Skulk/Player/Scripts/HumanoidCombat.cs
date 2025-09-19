using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidCombat : MonoBehaviour
{
    GameObject ScriptOwner;
    GameObject Orientation;
    public GameObject Weapon;
    [SerializeField]Animator Animator;

    public bool IsBlocking;
    public bool IsParry;
    public bool IsSwinging;

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
            IsBlocking = true;
            IsParry = true;
        }
    }
    public void EndParryWindow()
    {
        IsParry = false;
    }
}
