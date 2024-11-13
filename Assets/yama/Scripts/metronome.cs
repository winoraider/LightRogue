using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metronome : MonoBehaviour
{
    float count;
    AudioSource AS;

    private void Start()
    {
        AS = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        count += Time.deltaTime;
        if(count > 0.5)
        {
            AS.Play();
            count = 0;
        }
    }
}
