using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] int _numberOfTrafficLanes = 4;
    [SerializeField] float _distanceToFarLane = 20.0f;
    [SerializeField] float _distanceBetweenSpawns = 15.0f;

    [Header("Cars")]
    [SerializeField] GameObject[] _passingCarPrefabs;

    [Header("Fuel")]
    [SerializeField] GameObject _fuelPrefab;
    [SerializeField] float _fuelSpawnProbability = 0.1f;

    GameObject _lastSpawnedObject;
    float _distanceBetweenTrafficLanes;

    void Start()
    {
        _distanceBetweenTrafficLanes = _distanceToFarLane / _numberOfTrafficLanes;
        SpawnFuel();
    }

    void Update()
    {
        float distanceToLastSpawnedObject = transform.position.z - _lastSpawnedObject.transform.position.z;
        if (distanceToLastSpawnedObject > _distanceBetweenSpawns)
        {
            if (Random.Range(0.0f, 1.0f) > _fuelSpawnProbability)
            {
                SpawnCar();
            }
            else
            {
                SpawnFuel();
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        float xPosition = transform.position.x + Random.Range(0, _numberOfTrafficLanes) * _distanceBetweenTrafficLanes;
        return new Vector3(xPosition, transform.position.y, transform.position.z);
    }

    void SpawnCar()
    {
        Vector3 spawnPosition = GetRandomPosition();
        GameObject car = _passingCarPrefabs[Random.Range(0, _passingCarPrefabs.Length)];
        _lastSpawnedObject = Instantiate(car, spawnPosition, transform.rotation);
    }

    void SpawnFuel()
    {
        Vector3 spawnPosition = GetRandomPosition();
        _lastSpawnedObject = Instantiate(_fuelPrefab, spawnPosition, transform.rotation);
    }
}
