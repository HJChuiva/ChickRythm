using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFlame : MonoBehaviour
{
    AudioSource myAudio;
    bool musicStart = false;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        myAudio.Play();
        if (!musicStart)
        {
            if (collision.CompareTag("Note"))
            {
                Debug.Log("fuck");
                myAudio.Play();
                musicStart = true;
            }
        }
    }
}
