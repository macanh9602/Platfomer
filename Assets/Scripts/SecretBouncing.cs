using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBouncing : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            float t = 0;
            if(t<5)
            {
                t += Time.deltaTime;
                float DoMo = Mathf.Lerp(0, 255, t/5);
                Debug.Log(DoMo);
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, DoMo);
            }

        }
    }
}
