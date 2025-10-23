using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class AIBrain : MonoBehaviour
{
    AIEyes AIEyes;
    [SerializeField] GameObject Player;
    public Vector3 Destination;
    Vector3 NextDestination;
    [Header("BehaiviorPriority")]
    [SerializeField] float RoamPriority;
    [SerializeField] float SeekPriority;
    [Header("Roam")]
    public bool RoamBehaviour;
    [SerializeField] float RoamRange;
    [Header("Seek")]
    public bool SeekBehavior;
    [Header("Think Settings")]
    [SerializeField] float ThinkTimer;
    float ThinkTime;
    private void Start()
    {
        AIEyes = gameObject.GetComponent<AIEyes>();

        if (AIEyes == null)
        {
            Debug.Log(gameObject.name + " Succesfully got all components for (AIBrain.cs)");
        }
        else
        {
            Debug.LogWarning(gameObject.name + "Unsuccesfull with gathering components for (AIBrain.cs)");
        }
            Destination = gameObject.transform.position;
    }
    void Update()
    {
        //all of this will be removed and changed to fit the "think" function

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
        if (NextDestination == Vector3.zero)
        {
            if (RoamBehaviour)
            {
                NextDestination += Roam();
            }
            else if (SeekBehavior)
            {
                NextDestination += Seek();
            }
            if (Vector3.Distance(gameObject.transform.position, Destination) < 1)
            {
                Destination = NextDestination;
                NextDestination = Vector3.zero;
            }
        }
    }

    Vector3 Roam()
    {
        while (Vector3.Distance(gameObject.transform.position, Destination) < 1)
        {
            float RandomX = Random.Range(gameObject.transform.position.x - RoamRange, gameObject.transform.position.x + RoamRange);
            float RandomZ = Random.Range(gameObject.transform.position.z - RoamRange, gameObject.transform.position.z + RoamRange);

            return new Vector3(RandomX, gameObject.transform.position.y, RandomZ) * RoamPriority;
        }
        return Vector3.zero;
    }

    Vector3 Seek()
    {
        if (AIEyes.SeeingPlayer)
        {
            Vector3 DesiredPosition = Player.transform.position + (Player.transform.position - gameObject.transform.position).normalized * 10;
            return DesiredPosition * SeekPriority;
        }
        return Vector3.zero;
    }
}


