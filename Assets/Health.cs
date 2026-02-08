using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public int defaultHealthPoint = 1;
    private int healthPoint;

    public GameObject explosionPrefab;

    private void Start()
    {
        healthPoint = defaultHealthPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;

        healthPoint -= damage;

        if (healthPoint <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(
                explosionPrefab,
                transform.position,
                transform.rotation
            );

            Destroy(explosion, 1f);
        }

        Destroy(gameObject);
    }
}
