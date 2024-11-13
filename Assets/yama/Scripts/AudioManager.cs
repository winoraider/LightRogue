using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource redurceSound;
    [SerializeField] AudioSource brokenSound;

    public void RedurcePlay()
    {
        redurceSound.Play();
    }

    public void BrokenPlay()
    {
        brokenSound.Play();
    }
}
