using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject projectilePrefab;
    GameObject projectile;    
    
    public void FireGun(float direction)
    {
        projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction, 0f);
    }


}
