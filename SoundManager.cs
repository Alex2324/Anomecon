using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    [SerializeField]

    private AudioClip[] stepClips;
    public AudioClip[] swordClips;
    public AudioClip[] punchClips;
    public AudioClip deathClip;
    public AudioClip interactClip;
    private AudioSource audioSource;
    private bool attacking;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Step()
    {
        AudioClip step = GetRandomStepClip();
        audioSource.PlayOneShot(step);
    }

    void SwordAttack()
    {
        attacking = true;
        AudioClip attack = GetRandomSwordClip();
        audioSource.PlayOneShot(attack);
    }

    void Punch() {
        attacking = true;
        AudioClip punch = GetRandomPunchClip();
        audioSource.PlayOneShot(punch);
    }

    void Death() {  
        audioSource.PlayOneShot(deathClip);
    }

    void Interact() {
        audioSource.PlayOneShot(interactClip);
    }

    private AudioClip GetRandomStepClip()
    {
        return stepClips[UnityEngine.Random.Range(0, stepClips.Length)];
    }
    private AudioClip GetRandomSwordClip()
    {
        return swordClips[UnityEngine.Random.Range(0, swordClips.Length)];
    }
    private AudioClip GetRandomPunchClip()
    {
        return punchClips[UnityEngine.Random.Range(0, punchClips.Length)];
    }
    void Update()
    {
        if (GetComponent<Rigidbody>().IsSleeping() && !attacking)
        {
            this.audioSource.Pause();
        }

        if(attacking)
        {
            this.audioSource.UnPause();
        }
    }
}
