using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedBulletEnemy : MonoBehaviour
{
    [SerializeField] public float speedBullet;

    private Rigidbody2D rb;

    private void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speedBullet;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<HealthPlayer>().takeDamage(1);
        }
    }


}
