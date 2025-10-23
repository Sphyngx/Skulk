using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.XR;
public class AIBehaviour : ScriptableObject
{
    public bool LookForPlayer;
    public virtual bool Conditions()
	{
        return Conditions();
	}
	public virtual void ConditionsMet()
	{

	}
    public virtual void ConditionsNotMet()
    {

    }
    public virtual void Roam()
    {
        /*
        float RandomX = Random.Range(gameObject.transform.position.x - RoamRange, gameObject.transform.position.x + RoamRange);
        float RandomZ = Random.Range(gameObject.transform.position.z - RoamRange, gameObject.transform.position.z + RoamRange);

        Vector3 RandomDestination;
        RandomDestination = new Vector3(RandomX, gameObject.transform.position.y, RandomZ);
        */
    }
}

[CreateAssetMenu(menuName = "My Assets/Aggressive")]
class Aggressive : AIBehaviour
{
    public override void ConditionsMet()
    {
        
    }
    public override void ConditionsNotMet()
    {
        
    }
}

[CreateAssetMenu(menuName = "My Assets/Frightned")]
class Frightned : AIBehaviour
{
	
}

class LookForPlayer : AIBehaviour
{
    public override bool Conditions()
    {
        return true;
    }
}
class Roaming : AIBehaviour
{

}

