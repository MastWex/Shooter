using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float damage = 10;

    public Bullet BulletPrefab;
    public Transform MuzzleTransform;
    
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(BulletPrefab, MuzzleTransform.position, MuzzleTransform.rotation);
            bullet.damage = damage;
        }
    }
}
