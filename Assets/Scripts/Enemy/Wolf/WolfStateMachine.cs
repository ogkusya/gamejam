using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class WolfStateMachine : MonoBehaviour
{
    [Header("Movement Properties")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float speedRotate = 15f;
    [SerializeField] private Transform centerLocation;
    [SerializeField] private Vector2 radiusLocation = new Vector2(1, 13);

    [Header("User Output")]
    [SerializeField] private string currentState;
    [SerializeField] private string currentVelocity;

    public WolfAnimatorController WolfAnimatorController { get; private set; }

    private StateMachine _stateMachine;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(centerLocation.position, new Vector3(radiusLocation.x, 0.1f, radiusLocation.y));
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        InitializeStateMachine();
    }

    private void Update()
    {
        _stateMachine.OnUpdate();
        currentState = _stateMachine.CurrentState.ToString();
        currentVelocity = _rigidbody.velocity.ToString();
    }

    private void FixedUpdate()
    {
        _stateMachine.OnFixedUpdate();
    }

    private void InitializeStateMachine()
    {
        WolfAnimatorController wolfAnimatorController = new WolfAnimatorController(_animator);
        WolfAnimatorController = wolfAnimatorController;

        var walkState = new WolfWalkState(WolfAnimatorController, _rigidbody, speed, speedRotate, centerLocation, radiusLocation);



        _stateMachine = new StateMachine(walkState);
    }
}
