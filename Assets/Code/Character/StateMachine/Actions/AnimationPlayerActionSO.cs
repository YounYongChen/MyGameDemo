using UnityEngine;
using Kill.StateMachine;
using Kill.StateMachine.ScriptableObjects;
using Moment = Kill.StateMachine.StateAction.SpecificMoment;

[CreateAssetMenu(fileName = "AnimationPlayerAction", menuName = "State Machines/Actions/Animation Player Action")]
public class AnimationPlayerActionSO : StateActionSO
{
	[Header("要播放的动画片段")]
	public string AnimClip = "";
	[Header("动画播放时机")]
	public Moment whenToRun = default;
	

	protected override StateAction CreateAction() => new AnimationPlayerAction(AnimClip);
}

public class AnimationPlayerAction : StateAction
{
    private string _animClip;
	private Animator _animator;

    public AnimationPlayerAction(string animClip)
    {
        this._animClip = animClip;
    }

	private new AnimationPlayerActionSO OriginSO => (AnimationPlayerActionSO)base.OriginSO;

	public override void Awake(StateMachine stateMachine)
	{
		_animator = stateMachine.GetComponent<Animator>();
	}
	
	public override void OnUpdate()
	{
		if (Moment.OnUpdate == OriginSO.whenToRun)
		{
			_animator.Play(_animClip);
		}
	}
	
	public override void OnStateEnter()
	{
		if (Moment.OnStateEnter == OriginSO.whenToRun) {
			_animator.Play(_animClip,0 ,0);
		}
	}
	
	public override void OnStateExit()
	{
		if (Moment.OnStateExit == OriginSO.whenToRun)
		{
			_animator.Play(_animClip);
		}
	}
}
