using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    //hello
    [SerializeField] public float runSpeed = 10f;
    [SerializeField] public float jumpSpeed = 5f;
    [SerializeField] public float climbSpeed = 10f;
    Vector2 moveInput;
    Rigidbody2D myrigidbody2D;
    Animator myAnimator;
    CapsuleCollider2D myBodycollider2D;
    float gravityStart;
    public bool isGrounded;
    bool isAlive = true;
    public GameObject bullets;
    public GameObject gun;
    public AudioClip gunSound;
    public AudioClip dieSound;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodycollider2D = GetComponent<CapsuleCollider2D>();
        gravityStart = myrigidbody2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Run();
        flipFace();
        climbingLadder();
        myAnimator.SetFloat("yVelocity", myrigidbody2D.velocity.y);
        Die();
    }
    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (value.isPressed && myBodycollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {

            myrigidbody2D.velocity = new Vector2(0f, jumpSpeed);

            myAnimator.SetBool("Jump", true);

        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            myAnimator.SetBool("Jump", false);
        }
    }

    void Run()
    {
        bool IsHorizontalMoving = Mathf.Abs(myrigidbody2D.velocity.x) > 0;
        Vector2 myvelocity = new Vector2(moveInput.x * runSpeed, myrigidbody2D.velocity.y);
        myrigidbody2D.velocity = myvelocity;
        myAnimator.SetBool("IsRunning", IsHorizontalMoving);
    }
    void flipFace()
    {
        bool IsHorizontalMoving = Mathf.Abs(myrigidbody2D.velocity.x) > 0;
        if (IsHorizontalMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(myrigidbody2D.velocity.x), transform.localScale.y);
        }

    }
    void Die()
    {
        if (myBodycollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Trap")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Die");
            myrigidbody2D.velocity = new Vector2(20f, 20f);
            myBodycollider2D.isTrigger = true;
            AudioSource.PlayClipAtPoint(dieSound, this.transform.position);

            // Load scene 1 after a delay of 2 seconds
            Invoke("LoadScene1", 2f);
        }
    }
    void LoadScene1()
    {
        SceneManager.LoadScene(0);
        Score.score = 0;
    }
    void climbingLadder()
    {

        if (myBodycollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            Vector2 myvelocity = new Vector2(myrigidbody2D.velocity.x, moveInput.y * climbSpeed);
            myrigidbody2D.velocity = myvelocity;
            myrigidbody2D.gravityScale = 0;
        }
        else myrigidbody2D.gravityScale = gravityStart;

    }

    IEnumerator ResetShootAnimation()
    {
        yield return new WaitForSeconds(0.4f); // Chờ 0.4 giây trước khi thiết lập lại animation
        myAnimator.SetBool("Shoot", false); // Đặt lại animation shoot
    }

    void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        if (value.isPressed)
        {
            AudioSource.PlayClipAtPoint(gunSound, this.transform.position);
            myAnimator.SetBool("Shoot", true);
            Instantiate(bullets, gun.transform.position, bullets.transform.rotation);

            StartCoroutine(ResetShootAnimation()); // Bắt đầu coroutine để đặt lại animation shoot
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            Score.score++;
            Score.lastScore = Score.score;
            Debug.Log(Score.lastScore);
        }
    }
}

