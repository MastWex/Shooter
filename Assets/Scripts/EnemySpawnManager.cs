using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    private List<Transform> enemySpawnerList;
    public List<Transform> targetPoints;
    public EnemyAI enemyPrefab;
    public PlayerController playerController;
    private float _time;
    public float spawnInterval = 3f;

    private void Start()
    {
        enemySpawnerList = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        enemySpawnerList.Remove(transform);
    }
    void Update()
    {
        if (Timer())
        {
            SpawnEnemy();
        }
    }

    private bool Timer()
    {
        _time += Time.deltaTime;
        if (_time > spawnInterval)
        {
            _time = 0;
            return true;
        }
        else return false;
    }
    private int PickSpawnPoint()
    {
        return Random.Range(0, enemySpawnerList.Count);
    }
    private void SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = enemySpawnerList[PickSpawnPoint()].transform.position;
        enemy.Player = playerController;
        enemy.PlayerHealth = playerController.GetComponent<PlayerHealth>();
        enemy.patrolPoints = targetPoints;
        enemy.GetComponent<EnemyHealth>().playerProgress = playerController.GetComponent<PlayerProgress>();
    }
}
