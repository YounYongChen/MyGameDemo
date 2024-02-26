using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : DescriptionBaseSO, GameInput.IGamePlayActions
{
    private GameInput _gameInput;

    public event UnityAction RollEvent = delegate { };
    public event UnityAction AttackEvent = delegate { };
    public event UnityAction<Vector2> MoveEvent = delegate { };

    private void OnEnable()
    {
        if (_gameInput == null) {
            _gameInput = new GameInput();
            _gameInput.GamePlay.SetCallbacks(this);
        }
        _gameInput.Enable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        AttackEvent.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        RollEvent.Invoke();
    }

}
