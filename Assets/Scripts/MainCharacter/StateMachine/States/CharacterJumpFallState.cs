using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpFallState : State
{
    private readonly CharacterAnimatorController _characterAnimationController;
    private Animator _animator;
    private readonly InputManager _inputManager;
    private readonly Rigidbody _rigidBody;
    private readonly ParticleSystem _particleSystem;
    private readonly float _speed;
    private readonly float _speedRotate;
    private readonly float _forceJump;
    private bool isCanAirJump;

    public CharacterJumpFallState(CharacterAnimatorController characterAnimationController, Animator animator, InputManager inputManager, Rigidbody rigidBody,ParticleSystem particleSystem, float speed, float speedRotate, float forceJump)
    {
        _characterAnimationController = characterAnimationController;
        _animator = animator;
        _inputManager = inputManager;
        _rigidBody = rigidBody;
        _speed = speed;
        _speedRotate = speedRotate;
        _forceJump = forceJump;
        _particleSystem = particleSystem;
    }

    public override void OnStateEntered()
    {
        isCanAirJump = true;
        Jump();
        _characterAnimationController.SetBool(CharacterAnimationType.JumpBool, true);
    }

    public override void OnStateExited()
    {
        _characterAnimationController.SetBool(CharacterAnimationType.JumpBool, false);
    }

    // called every frame
    public override void Tick()
    {
        if (_inputManager.IsJumping && isCanAirJump && _animator.GetBool("DoubleJump"))
        {
            isCanAirJump = false;
            Jump();
        }
    }

    public override void OnFixedUpdate()
    {
        if (_rigidBody.velocity.y != 0)
        {
            Move();
            Rotate2();
        }
    }

    private void Jump()
    {
        _rigidBody.velocity = Vector3.up * _forceJump;
        _particleSystem.Play();
        //_rigidBody.AddForce(Vector3.up * _forceJump);
    }

    private void Move()
    {
        _rigidBody.velocity = new Vector3(0, _rigidBody.velocity.y, _inputManager.MoveDirectionHorizontal * _speed);
    }

    private void Rotate2()
    {
        if (_rigidBody.velocity != Vector3.zero)
        {
            _rigidBody.MoveRotation(Quaternion.LookRotation(new Vector3(0, 0, _rigidBody.velocity.z)));
        }
    }
}
