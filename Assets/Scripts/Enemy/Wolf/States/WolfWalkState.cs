using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfWalkState : State
{
    private readonly WolfAnimatorController _wolfAnimatorController;
    private readonly Rigidbody _rigidBody;
    private readonly Vector3 _centerLocation;
    private readonly Vector2 _diameterWalk;
    private readonly float _speed;
    private readonly float _speedRotate;
    private int _direction;


    public WolfWalkState(WolfAnimatorController enemyAnimatorController, Rigidbody rigidBody, float speed, float speedRotate, Transform centerLocation, Vector2 diameterWalk)
    {
        _wolfAnimatorController = enemyAnimatorController;
        _rigidBody = rigidBody;
        _centerLocation = centerLocation.position;
        _diameterWalk = diameterWalk;
        _speed = speed;
        _speedRotate = speedRotate;
    }

    public override void OnStateEntered()
    {
        _direction = Random.Range(0, 2) == 0 ? -1 : 1;
        _wolfAnimatorController.SetBool(WolfAnimationType.Walk, true);
    }

    public override void OnStateExited()
    {
        _wolfAnimatorController.SetBool(WolfAnimationType.Walk, false);
        _rigidBody.velocity = Vector3.zero;
    }

    public override void OnFixedUpdate()
    {
        Debug.Log("_rigidBody.transform.position.z: " + _rigidBody.transform.position.z);
        Debug.Log("_centerLocation.z: " + _centerLocation.z);
        Debug.Log("_radiusWalk.y: " + _diameterWalk.y);

        if ((_rigidBody.transform.position.z < _centerLocation.z - _diameterWalk.y / 2) || (_rigidBody.transform.position.z > _centerLocation.z + _diameterWalk.y / 2))
        {
            _direction = -_direction;
        }

        Move();
        Rotate2();
    }

    private void Move()
    {
        _rigidBody.velocity = new Vector3(0, 0, _direction * _speed);
    }

    private void Rotate2()
    {
        if (_rigidBody.velocity != Vector3.zero)
        {
            _rigidBody.MoveRotation(Quaternion.LookRotation(new Vector3(0, 0, _rigidBody.velocity.z)));
        }
    }
}
