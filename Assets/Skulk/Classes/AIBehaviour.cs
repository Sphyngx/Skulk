using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.XR;
public class AIBehaviour : ScriptableObject
{
	
    public virtual bool LookForPlayer()
	{
		return false;
	}
	public virtual void ConditionsMet()
	{

	}
    public virtual void ConditionsNotMet()
    {

    }
}

[CreateAssetMenu(menuName = "My Assets/Aggressive")]
class Aggressive : AIBehaviour
{
    public override bool LookForPlayer()
    {
		return true;
    }
}

[CreateAssetMenu(menuName = "My Assets/Frightned")]
class Frightned : AIBehaviour
{
	
}


