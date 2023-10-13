using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private Transform _target;
    private float _speed;
    private float _minDistance;
    private Vector3 _moveDirection;

    private void Update()
    {
        SetMoveDirection(_target);
        Move();
    }

    private void Move()
    {
        transform.forward = _moveDirection;

        if(Vector3.Distance(_target.transform.position, transform.position) > _minDistance)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }

    private void SetMoveDirection(Transform target)
    {
        _moveDirection = (target.transform.position - transform.position).normalized;
        _moveDirection.y = 0;
    }

    public void Init(Transform target, float speed, float minDistance)
    {
        _target = target;
        _speed = speed;
        _minDistance = minDistance;
    }
}
