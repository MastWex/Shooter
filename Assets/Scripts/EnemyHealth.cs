using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public PlayerProgress playerProgress;
    public float Value = 100;
    public float exp = 50;

    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }
    public void DealDamage(float damage)
    {
        Value -= damage;
        if (Value <= 0)
        {
            playerProgress.AddExperience(exp);
            Destroy(gameObject);
        }
    }
}
