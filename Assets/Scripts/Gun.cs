using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public GameObject projectilePrefab;
    GameObject projectile;

    private AudioSource audioSource;
    private Blast blast;

    private PlayerController player;
    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        blast = GameObject.FindObjectOfType<Blast>();
    }

    public void FireGun(float direction)
    {
        Vector3 rotation = new Vector3(0f, 0f, 180);
        bool facingRight = player.WhichDirectionFace();
        if (facingRight)
        {
            audioSource.Play();
            projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction, 0f);
        }
        else if (!facingRight)
        {
            audioSource.Play();
            projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(new Vector3(0f, 0f, 180f)));
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction, 0f);
        }
    }


}
