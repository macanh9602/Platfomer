using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed = 5f;
    PlayerMovement player;
    float xSpeed;
    // Start is called before the first frame update
    void Start()
    {
     
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x; 
    }

    // Update is called once per frame
    void Update()
    { 
        rb.transform.localScale = new Vector2(xSpeed,rb.transform.localScale.y);
        rb.velocity = new Vector2(xSpeed * bulletSpeed, 0f);
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
