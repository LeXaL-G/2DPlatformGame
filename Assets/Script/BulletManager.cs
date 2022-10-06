using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float lifeTime,bulletDamage;
    void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Enemie")
            Destroy(gameObject);
    }
}
