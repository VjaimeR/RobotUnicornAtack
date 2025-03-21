using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
       
        if(instance == null)
        {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }
    public void EjectSound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
