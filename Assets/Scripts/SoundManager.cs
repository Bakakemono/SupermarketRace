using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField] private AudioSource AudioSourceCustomers;
    [SerializeField] private AudioSource AudioSourceGrandma1;
    [SerializeField] private AudioSource AudioSourceGrandma2;
    [SerializeField] private AudioClip customerSound;
    [SerializeField] private AudioClip[] GrandmaSound;

    public void PlayCustomerHit()
    {
        AudioSourceCustomers.clip = customerSound;
        AudioSourceCustomers.Play();
    }
    public void PlayGrandmaHitWall()
    {
        int IndexSoundRandom = Random.Range(0, GrandmaSound.Length-2);
        AudioSourceGrandma1.clip = GrandmaSound[IndexSoundRandom];
        AudioSourceGrandma1.Play();
    }
    public void PlayGrandmaHitCustomers()
    {
        int IndexSoundRandom = Random.Range(2, GrandmaSound.Length);
        AudioSourceGrandma2.clip = GrandmaSound[IndexSoundRandom];
        AudioSourceGrandma2.Play();
    }
}
