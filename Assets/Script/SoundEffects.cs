using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    // Reference to the AudioSource component that will play the sound effect.
    public AudioSource src;

    // The audio clip to be played.
    public AudioClip sfx;

    void Start() // Fixed capitalization from 'start' to 'Start'
    {
        // Ensure the AudioSource and AudioClip are assigned before playing.
        if (src != null && sfx != null)
        {
            src.clip = sfx; // Assign the sound effect to the AudioSource.
            src.Play(); // Play the sound effect.
        }
        else
        {
            Debug.LogWarning("SoundEffects: Missing AudioSource or AudioClip reference!");
        }
    }
}
