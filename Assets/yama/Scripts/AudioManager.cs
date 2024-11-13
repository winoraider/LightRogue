using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip redurceSound;
    [SerializeField] AudioClip brokenSound;
    AudioSource AudioSource;

    private void Start()
    {
        AudioSource = this.gameObject.GetComponent<AudioSource>();
    }
    public void RedurcePlay()
    {
        AudioSource.PlayOneShot(redurceSound);
    }

    public void BrokenPlay()
    {
        Debug.Log("sinnda");
        AudioSource.PlayOneShot(brokenSound);
    }
}
