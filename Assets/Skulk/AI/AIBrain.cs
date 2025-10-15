using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    AIEyes AIEyes;
    [Header("Roaming")]
    public bool RoamBehaviour;
    public bool AtDestination;
    [SerializeField] float RoamRange;
    [SerializeField] float RoamTimer = 0;
    [SerializeField] float RoamTimerMax;
    public Vector3 RandomDestination;
    [Header("FollowTarget")]
    public bool FollowTarget;
    public GameObject Target;
    [Header("Think Settings")]
    [SerializeField] float ThinkTimer;
    float ThinkTime;
    void Update()
    {
        //all of this will be removed and changed to fit the "think" function

        if (RoamBehaviour)
        {
            if (RoamTimer >= RoamTimerMax)
            {
                FindDestination();
                AtDestination = false;
                RoamTimer = 0;
            }
        }
        if (RoamBehaviour && Vector3.Distance(gameObject.transform.position,RandomDestination) < 0.1f)
        {
            AtDestination = true;
            RoamTimer += Time.deltaTime;
        }

        if (FollowTarget)
        {
            if (AIEyes.SeeingPlayer)
            {
                Target = AIEyes.Player;

            }
            else
            {
                Target = null;
            }
        }

        //Think functionality

        ThinkTime += Time.deltaTime;
        if (ThinkTimer < ThinkTime)
        {
            Think();
            ThinkTime = 0;
        }
    }

     void Think()
    {
        Debug.Log(gameObject.name + " Had a Thought");
        //gather variables from Behaviours

        /*switch (Behaviour[])
        {
            case Fighter:Behaviour[0]; 
                priority == player
                break;
            case Frightened:Behaviour[1]; 
                prioriry == get away from player / run randomly
                break;
            case ???:Behaviour[2]; 
                
                break;
        }*/

    }

    void FindDestination()
    {
        if (RoamBehaviour)
        {
            float RandomX = Random.Range(gameObject.transform.position.x - RoamRange, gameObject.transform.position.x + RoamRange);
            float RandomZ = Random.Range(gameObject.transform.position.z - RoamRange, gameObject.transform.position.z + RoamRange);

            RandomDestination = new Vector3(RandomX, gameObject.transform.position.y, RandomZ);
        }
    }
}


