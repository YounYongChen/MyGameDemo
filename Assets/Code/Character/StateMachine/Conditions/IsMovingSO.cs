using UnityEngine;
using Kill.StateMachine;
using Kill.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsMoving", menuName = "State Machines/Conditions/Is Moving")]
public class IsMovingSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsMoving();
}

public class IsMoving : Condition
{
	private StateMachine _stateMachine;
	protected new IsMovingSO OriginSO => (IsMovingSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_stateMachine = stateMachine;
	}
	
	protected override bool Statement()
	{
		MainCharacter mainCharacter = _stateMachine.GetComponent<MainCharacter>();
		return mainCharacter.movementVector.x != 0 || mainCharacter.movementVector.z != 0;
	}
 
}
