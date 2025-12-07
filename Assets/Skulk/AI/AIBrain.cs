using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class AIBrain : MonoBehaviour
{
    [SerializeField] bool ShowDebug;
    AIEyes AIEyes;
    CharacterController Controller;
    HumanoidCombat HumanoidCombat;
    public float MaxSpeed;
    [SerializeField] float MaxSteeringForce;
    GameObject Player;
    [SerializeField] Animator PlayerAnimator;
    [NonSerialized] public Vector3 Steering;
    [Header("Arrive")]
    [SerializeField] float SlowingRadius;
    [Header("Roam")]
    [SerializeField] bool RoamBehaviour;
    [SerializeField] float RoamPriority;
    [SerializeField] float RoamRange;
    [Header("Seek")]
    [SerializeField] bool SeekBehavior;
    [SerializeField] float SeekPriority;
    [SerializeField] GameObject SeekTarget;
    [Header("Flee")]
    [SerializeField] bool FleeBehaviour;
    [SerializeField] float FleePriority;
    [SerializeField] GameObject FleeTarget;
    [SerializeField] float AvoidanceRadius;
    [Header("AntiGank")]
    [SerializeField] bool AntiGankBehaviour;
    [SerializeField] float AntiGankPriority;
    [Header("Think Settings")]
    [SerializeField] float ActionTimer;
    float ActionTime;

    private void Start()
    {
        AIEyes = gameObject.GetComponent<AIEyes>();

        Controller = gameObject.GetComponent<CharacterController>();

        HumanoidCombat = gameObject.GetComponent<HumanoidCombat>();

        Player = GameObject.FindGameObjectWithTag("Player");

        if (AIEyes != null && Player != null && HumanoidCombat != null && Controller != null)
        {
            Debug.Log(gameObject.name + " Succesfully got all components for (AIBrain.cs)");
        }
        else
        {
            Debug.LogWarning(gameObject.name + "Unsuccesfull with gathering components for (AIBrain.cs)");
        }
    }
    void Update()
    {
        //Think functionality
        Think();
    }

    void Think()
    {
        if (RoamBehaviour)
        {
            Steering += Roam() * RoamPriority;
        }
        if (SeekBehavior)
        {
            Vector3 SeekWill = Seek() * SeekPriority;

            Steering += SeekWill;
            if (ShowDebug)
            {
                Debug.DrawRay(transform.position, SeekWill, Color.red);
            }
        }
        if (FleeBehaviour)
        {
            Vector3 FleeWill = Flee() * FleePriority;

            Steering += FleeWill;
            if (ShowDebug)
            {
                Debug.DrawRay(transform.position, FleeWill, Color.blue);
            }

        }
        if (AntiGankBehaviour)
        {
            Vector3 AntiGankWill = AntiGank() * AntiGankPriority;

            Steering += AntiGankWill;
            if (ShowDebug)
            {
                Debug.DrawRay(transform.position, AntiGankWill, Color.magenta);
            }
        }

        //Combat Under

        ActionTime += Time.deltaTime;
        if (ActionTimer <= ActionTime && AIEyes.SeeingPlayer)
        {
            if (Vector3.Distance(gameObject.transform.position, Player.transform.position) <= 4 && !PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("AttackState"))
            {
                HumanoidCombat.MeleeM1();
            }
            if (PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attackstate"))
            {
                HumanoidCombat.Block();
            }
            ActionTime = 0;
        }

        if (ShowDebug)
        {
            Debug.DrawRay(transform.position, Steering, Color.yellow); //Steering visualized
        }
    
        //if (Steering + Controller.velocity != Vector3.zero) //Arrive function baked into think
        //{
        //    float Distance = Vector3.Distance(transform.position, Player.transform.position);
        //    if (Distance < SlowingRadius)
        //    {
        //        Steering = Steering.normalized * MaxSpeed * (Distance / SlowingRadius);
        //    }
        //}
    }

    Vector3 Roam() //doesnt work
    {
        float RandomX = UnityEngine.Random.Range(gameObject.transform.position.x - RoamRange, gameObject.transform.position.x + RoamRange);
        float RandomZ = UnityEngine.Random.Range(gameObject.transform.position.z - RoamRange, gameObject.transform.position.z + RoamRange);

        return new Vector3(RandomX, gameObject.transform.position.y, RandomZ) - Controller.velocity;
    }

    Vector3 Seek()
    {
        float speed = MaxSpeed;
        Vector3 DesiredVector = SeekTarget.transform.position - transform.position;
        float distance = DesiredVector.magnitude;

        if(distance < MaxSpeed)
        {
            speed = distance;
        }

        DesiredVector = DesiredVector.normalized * speed;

        if (SeekTarget.CompareTag("Player"))
        {
            if (AIEyes.SeeingPlayer)
            {
                return DesiredVector;
            }
            return Vector3.zero;
        }
        else
        {
            return DesiredVector;
        }
    }

    Vector3 Flee()
    {
        float speed = MaxSpeed;
        Vector3 DesiredVector = FleeTarget.transform.position - transform.position;
        DesiredVector = DesiredVector.normalized * MaxSpeed;
        float Distance = Vector3.Distance(transform.position, FleeTarget.transform.position);

        if (Distance < AvoidanceRadius)
        {
            if (AvoidanceRadius - Distance > MaxSpeed)
            {
                speed = MaxSpeed;
            }
            speed = AvoidanceRadius - Distance;
        }

        if (FleeTarget.CompareTag("Player"))
        {
            if (AIEyes.SeeingPlayer)
            {
                return (-DesiredVector - Controller.velocity);
            }
            return Vector3.zero;
        }
        else
        {
            return (-DesiredVector - Controller.velocity);
        }
    }

    Vector3 AntiGank()
    {
        GameObject[] EnemyAIAgents = GameObject.FindGameObjectsWithTag("EnemyAIAgent");
        GameObject ClosestToPlayer = null;
        float ClosestDist = Mathf.Infinity;

        if (AIEyes.SeeingPlayer)
        {
            for (int i = 0; i < EnemyAIAgents.Length; i++)
            {
                float Distance = Vector3.Distance(EnemyAIAgents[i].transform.position, Player.transform.position);

                if (Distance < ClosestDist)
                {
                    ClosestDist = Distance;
                    ClosestToPlayer = EnemyAIAgents[i];
                }
            }
            if (gameObject == ClosestToPlayer)
            {
                return Vector3.zero;
            }
            else
            {
                Vector3 DesiredVector = (transform.position - Player.transform.position).normalized;
                return (DesiredVector * MaxSpeed - Controller.velocity) / Vector3.Distance(gameObject.transform.position, Player.transform.position);
            }
        }
        return Vector3.zero;
    }
}


