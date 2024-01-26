using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public AudioClip hurtSound;
    public AudioSource soundSource;

    private void Update()
    {

        if (!soundSource.isPlaying)
        {
            soundSource.clip = hurtSound;
            soundSource.Play();
        }
    }
}
