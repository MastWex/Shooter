using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float damage = 10f;

    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }
    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyBullet();
    }

    private void MoveFixedUpdate()
    {
        transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
    private void DamageEnemy(Collision collision)
    {
        var _enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (_enemyHealth != null)
        {
            _enemyHealth.DealDamage(damage);
        }

    }
}
