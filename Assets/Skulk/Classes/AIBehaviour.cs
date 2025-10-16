using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.XR;
public class AIBehaviour : ScriptableObject
{
    public virtual bool Conditions(AIEyes Eyes)
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
    public override bool Conditions(AIEyes Eyes)
    {
		

		return Eyes != null && Eyes.Look();
    }
	
}

[CreateAssetMenu(menuName = "My Assets/Frightned")]
class Frightned : AIBehaviour
{
	
}


