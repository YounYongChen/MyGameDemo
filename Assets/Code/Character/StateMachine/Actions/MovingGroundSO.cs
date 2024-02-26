using UnityEngine;
using Kill.StateMachine;
using Kill.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "MovingGround", menuName = "State Machines/Actions/Moving Ground")]
public class MovingGroundSO : StateActionSO
{
	public float step = 8;
	protected override StateAction CreateAction() => new MovingGround();
}

public class MovingGround : StateAction
{
	private MainCharacter mainCharacter;
	protected new MovingGroundSO OriginSO => (MovingGroundSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		mainCharacter = stateMachine.GetComponent<MainCharacter>();
	}
	
	public override void OnUpdate()
	{
		
	}
	
	public override void OnStateEnter()
	{

	}
	
	public override void OnStateExit()
	{

	}
}
