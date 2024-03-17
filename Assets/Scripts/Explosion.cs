using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float speed = 1;
    public float maxSize = 4;
    public float damage = 35;
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        Destroying();
    }

    private void Destroying()
    {
        transform.localScale += Vector3.one * speed * Time.deltaTime;
        if (transform.localScale.x > maxSize)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DealDamage(damage);
        }

        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(damage);
        }
    }
}
