using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;
    public float moveSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       myRigidbody2D.velocity = new Vector2(moveSpeed,0f);
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            moveSpeed = -moveSpeed;
            flipFace();
            Debug.Log(other.tag == "Ground");
        }
    }
    void flipFace()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody2D.velocity.x)), 1f);
    }
}
