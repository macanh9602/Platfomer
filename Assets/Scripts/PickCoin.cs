using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCoin : MonoBehaviour
{
    public AudioClip PickCoinSFX;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = PickCoinSFX;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("pick coin success!");
            audioSource.Play();
            StartCoroutine(DestroyAfterSound());
        }
    }

    IEnumerator DestroyAfterSound()
    {
        // Chờ đợi cho đến khi âm thanh phát xong
        yield return new WaitForSeconds(audioSource.clip.length);
        // Sau khi âm thanh phát xong, hủy đối tượng
        Destroy(gameObject);
    }

}
//AudioSource.PlayClipAtPoint(PickCoinSFX,this.transform.position);
