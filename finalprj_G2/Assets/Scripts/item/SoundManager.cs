using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { private set; get; }

    public AudioClip AttackClip;

    public AudioClip WalkClip;

    public AudioClip CollectItemClip;

    public AudioSource audioSource;

    public AudioSource WalkAudioSource;
    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StopWalkSound()
    {
        if(WalkAudioSource.isPlaying==true){
            WalkAudioSource.Stop();
        }
    }

    public void PlayWalkSound()
    {
        if (WalkAudioSource.isPlaying == false)
        {
            WalkAudioSource.Play();
        }
    }

    public void PlayAttackClip()
    {
        audioSource.PlayOneShot(AttackClip);
    }

    internal void PlayCollectSound()
    {
        audioSource.PlayOneShot(CollectItemClip);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
