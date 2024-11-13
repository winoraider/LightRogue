using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class AudioManager : MonoBehaviour
{
    AudioSource redurceSound;
    NumController numController;

    void Updata()
    {
        if(numController.Counter > 0.5f)
        {
            Debug.Log("otonatteru");
            redurceSound.Play();
        }
    }
}
