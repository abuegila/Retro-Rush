using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx;


    void start()
    {
        src.clip = sfx;
        src.Play();

    }

}
