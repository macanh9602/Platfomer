using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCoin : MonoBehaviour
{
    public AudioClip PickCoinSFX;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Player") 
       {
            Debug.Log("pick coin success!");
            AudioSource.PlayClipAtPoint(PickCoinSFX,this.transform.position);
            Destroy(this.gameObject);
            
       } 
    }

}
