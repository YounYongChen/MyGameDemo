using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainCharacter : MonoBehaviour
{
    [SerializeField]
    private InputReaderForMobile _inputReader;

    [SerializeField]
    private TransformAnchor _cameraTransformAnchor;

    [SerializeField]
    private TransformAnchor _playerTrasnformAnchor;

    private Vector2 _inputVector;
    private float _previousSpeed;
    private Rigidbody _rigidbody;
    private Animator animator;

    //由状态机访问的部分
    [NonSerialized] public Vector3 movementVector;
    [NonSerialized] public Transform playerTransform;
    [NonSerialized] public int stateFrameCount; //单个状态执行了多少次update

    private void OnEnable()
    {
        _inputReader.OnMoveEvent += OnMove;
        playerTransform = GetComponent<Transform>();
        _playerTrasnformAnchor.Provide(playerTransform);

        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        _playerTrasnformAnchor.Unset();
    }

    private void OnMove(Vector3 arg0)
    {
        movementVector = arg0;
        movementVector.y = 0;
    }

  

    private void Update()
    {
        
    }

    public void OnAnimatorMove()
    {
        _rigidbody.velocity = animator.velocity;
        Vector3 velocity = _rigidbody.velocity;
        velocity.y = 0f;
    }

}
