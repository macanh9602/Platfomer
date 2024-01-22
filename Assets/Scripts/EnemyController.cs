using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;
    public float moveSpeed = 3f;
    Animator animator;
    //public float timeStop = 3f;
    //public float t = 0;
    //[SerializeField] bool isWalk;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = transform.Find("Sprite").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody2D.velocity = new Vector2(moveSpeed, 0f);
        animator.SetBool("IsWalk", true);
        //StartCoroutine(Move(timeStop));      
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
        transform.Find("Sprite").localScale = new Vector2(-(Mathf.Sign(myRigidbody2D.velocity.x)), 1f);
    }
}
