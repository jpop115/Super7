using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float health = 100;    
    public GameObject player;
   
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Die();
	}

    private void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);            
            Invoke("Respawn", 3);
        }
    }

    private void Respawn()
    {
        Debug.Log("Trying to Respawn");
        Instantiate(player, new Vector3(-0.24f, 3.23f, 0f), Quaternion.identity);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
