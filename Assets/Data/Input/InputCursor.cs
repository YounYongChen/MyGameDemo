using UnityEngine;

public class InputCursor : MonoBehaviour
{
    [SerializeField]
    private InputReaderForMobile _inputReader;
    [SerializeField]
    private GameObject _confirmPrefab;

    private GameObject _confirmInstance;
    private Animator _cursorAnimator;

    private void Awake()
    {
        _confirmInstance = Instantiate(_confirmPrefab);
        _cursorAnimator = _confirmInstance.GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        _inputReader.OnMoveEvent += OnMoveInput;
    }

    private void OnDisable()
    {
        _inputReader.OnMoveEvent -= OnMoveInput;
    }

    private void OnMoveInput(Vector3 target)
    {
        _confirmInstance.transform.position = target;
        _cursorAnimator.Play("Confirmation");
    }

}
