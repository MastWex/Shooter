using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Bullet BulletPrefab;
    public Transform MuzzleTransform;
    
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(BulletPrefab, MuzzleTransform.position, MuzzleTransform.rotation);
        }
    }
}
