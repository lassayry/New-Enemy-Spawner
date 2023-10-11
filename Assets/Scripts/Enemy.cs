using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _target;
    private float _speed;
    private float _minDistance;

    private void Update()
    {
        Move(GetMoveDirection(_target));
    }

    private void Move(Vector3 moveDirection)
    {
        transform.forward = moveDirection;

        if(Vector3.Distance(_target.transform.position, transform.position) > _minDistance)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }

    private Vector3 GetMoveDirection(Transform target)
    {
        Vector3 moveDirection = (target.transform.position - transform.position).normalized;
        moveDirection.y = 0;

        return moveDirection;
    }

    public void Init(Transform target, float speed, float minDistance)
    {
        _target = target;
        _speed = speed;
        _minDistance = minDistance;
    }
}
