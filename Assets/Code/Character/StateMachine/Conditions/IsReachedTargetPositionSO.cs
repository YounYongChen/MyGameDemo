using UnityEngine;
using Kill.StateMachine;
using Kill.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsReachedTarget", menuName = "State Machines/Conditions/Is Reached Target")]
public class IsReachedTargetPositionSO : StateConditionSO
{
	protected override Condition CreateCondition() => new IsReachedTarget();
}

public class IsReachedTarget : Condition
{
	protected new IsReachedTargetPositionSO OriginSO => (IsReachedTargetPositionSO)base.OriginSO;
	private StateMachine _stateMachine;
	private MainCharacter _character;

	public override void Awake(StateMachine stateMachine)
	{
		_stateMachine = stateMachine;
	}
	
	protected override bool Statement()
	{
		float dis = Vector3.Distance(_character.movementVector, _character.playerTransform.position);
		return dis < .1f;
	}
	
	public override void OnStateEnter()
	{
		_character = _stateMachine.GetComponent<MainCharacter>();
	}
	
	public override void OnStateExit()
	{

	}
}
