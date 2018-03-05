using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSound : MonoBehaviour {

    [SerializeField]

    private AudioClip[] weaponClips;
    public AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    void Attack()
    {
        AudioClip attack = GetRandomAttackClip();
        audioSource.PlayOneShot(attack);
        Debug.Log("ATTACK SOUND!!!");
    }

    private AudioClip GetRandomAttackClip()
    {
        return weaponClips[UnityEngine.Random.Range(0, weaponClips.Length)];
    }
    void Update()
    {
       
    }
}
