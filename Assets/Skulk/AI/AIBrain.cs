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
    float RoamTime = 0;
    [SerializeField] float RoamTimer;
    public Vector3 RandomDestination;
    [Header("FollowTarget")]
    public bool FollowTarget;
    public GameObject Target;
    [Header("Think Settings")]
    [SerializeField] AIBehaviour SelectedAIBehaviour;
    AIBehaviour[] AIBehaviours;
    [SerializeField] float ThinkTimer;
    float ThinkTime;
    void Update()
    {
        //all of this will be removed and changed to fit the "think" function

        if (RoamBehaviour)
        {
            if (RoamTime >= RoamTimer)
            {
                FindDestination();
                AtDestination = false;
                RoamTime = 0;
            }
        }
        if (RoamBehaviour && Vector3.Distance(gameObject.transform.position,RandomDestination) < 0.1f)
        {
            AtDestination = true;
            RoamTime += Time.deltaTime;
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
            Think(SelectedAIBehaviour);
            ThinkTime = 0;
        }
    }

     void Think(AIBehaviour Behaviour)
    {
        Debug.Log(gameObject.name + " Had a Thought");
        //gather variables from Behaviours

        for (int i = 0; i < AIBehaviours.Length; i++)
        {
            if (AIBehaviours[i] == Behaviour) 
            {
                if (Behaviour.Conditions(AIEyes) == true)
                {
                    Behaviour.ConditionsMet();
                }
                else
                {
                    Behaviour.ConditionsNotMet();
                }
            }
        }
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


