using UnityEngine;
using Kill.StateMachine;
using Kill.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "RunAction", menuName = "State Machines/Actions/Run Action")]
public class RunActionSO : StateActionSO
{
	protected override StateAction CreateAction() => new RunAction();
}

public class RunAction : StateAction
{
	protected new RunActionSO OriginSO => (RunActionSO)base.OriginSO;

	private StateMachine _stateMachine;
	private MainCharacter _mainCharacter;
	private Vector3 _lastTarget;

	public override void Awake(StateMachine stateMachine)
	{
		_stateMachine = stateMachine;
	}
	
	public override void OnUpdate()
	{
		//输入发生改变
		if (_lastTarget != _mainCharacter.movementVector) {
			_mainCharacter.transform.GazeTarget(_mainCharacter.movementVector);
		}
	}
	
	public override void OnStateEnter()
	{
		_mainCharacter = _stateMachine.GetComponent<MainCharacter>();
		_mainCharacter.transform.GazeTarget(_mainCharacter.movementVector);
		_lastTarget = _mainCharacter.movementVector;
	}
	
	public override void OnStateExit()
	{
		_mainCharacter.movementVector = Vector3.zero;
	}
}
