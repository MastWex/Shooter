using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float ViewAngle;

    public List<Transform> patrolPoints;

    public PlayerController Player;

    private Transform _targetPoint;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;

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
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }

    private void PickNewPatrolPoint()
    {
        _targetPoint = patrolPoints[Random.Range(0, patrolPoints.Count)];
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            _navMeshAgent.destination = _targetPoint.position;
            if (_navMeshAgent.remainingDistance == 0)
            {
                PickNewPatrolPoint();
            }
        }
    }

    private void NoticePlayerUpdate()
    {
        var direction = Player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < ViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == Player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
    }
}