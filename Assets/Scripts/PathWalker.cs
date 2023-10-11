using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PathWalker : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _targetPointIndex;

    private void Start()
    {
        _points = _path.GetComponentsInChildren<Transform>().Skip(1).ToArray();

        Debug.Log(_points.Length);
    }

    private void Update()
    {
        Transform targetPoint = _points[_targetPointIndex];

        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        if(transform.position == targetPoint.transform.position)
        {
            TakeNextTargetPoint();
        }
    }

    private void TakeNextTargetPoint()
    {
        _targetPointIndex++;

        if(_targetPointIndex == _points.Length)
        {
            _targetPointIndex = 0;
        }
    }
}
