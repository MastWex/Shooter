using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;

    private Transform _targetPoint;

    private NavMeshAgent _navMeshAgent;

/// <summary>
/// ///////////////////////////////////////////////////
/// </summary>
    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
    }

    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }


/// <summary>
/// /////////////////////////////////////////////////////
/// </summary>
    void Update()
    {
        PatrolUpdate();
    }

    private void PickNewPatrolPoint()
    {
        _targetPoint = patrolPoints[Random.Range(0, patrolPoints.Count)];
    }
    private void PatrolUpdate()
    {
        _navMeshAgent.destination = _targetPoint.position;
        if (_navMeshAgent.remainingDistance == 0)
        {
            PickNewPatrolPoint();
        }
    }
}