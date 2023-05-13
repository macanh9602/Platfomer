using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MusicController : MonoBehaviour
{
    GameObject SoundBG;
    AudioSource audioSource;
    bool offSound = false;
    Button button;
    private void Start()
    {
        SoundBG = GameObject.Find("Main Camera");
        audioSource = SoundBG.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OffSound()
    {
        EventSystem.current.SetSelectedGameObject(null);
        audioSource.mute = !offSound;
        offSound = !offSound;
        Debug.Log("Nhac");
    }
}
