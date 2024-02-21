using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animations : MonoBehaviour
{
    private Animator _animator;
    public NavMeshAgent _navMeshAgent;




/// <summary>
/// ///////////////////////////////
/// </summary>
    void Start()
    {
        InitComponentLinks();
    }

    private void InitComponentLinks()
    {
        _animator = GetComponent<Animator>();
    }


/// <summary>
/// //////////////////////////////////
/// </summary>
    void Update()
    {
        if (_navMeshAgent.velocity != Vector3.zero)
        {
            _animator.SetTrigger("ToRun");
        }
        else
        {
            _animator.SetTrigger("ToIdle");
        }
    }
}
