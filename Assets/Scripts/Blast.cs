using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour {
    public float damage = 10f;
    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        Health health = collision.gameObject.GetComponent<Health>();

        if (!enemy)
        {
            return;
        }
        if (enemy && health)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
