using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistanceToTarget;
    [SerializeField] private float _secondsBetweenSpawns;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0, _secondsBetweenSpawns);
    }

    private void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(_prefab, transform.position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().Init(_target, _speed, _minDistanceToTarget);
    }
}
