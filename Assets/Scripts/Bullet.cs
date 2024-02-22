using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public float lifetime;

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
}
