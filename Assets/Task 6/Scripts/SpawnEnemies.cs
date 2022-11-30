using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private float _timeSpawn;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private List<GameObject> _spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private void LoopCoroutine()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(_timeSpawn);

        int randomPoint = Random.Range(0, _spawnPoints.Count);
        Instantiate(_enemy, _spawnPoints[randomPoint].transform.position, Quaternion.identity);

        LoopCoroutine();
    }
}
