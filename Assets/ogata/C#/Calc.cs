using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calc : MonoBehaviour
{
    public float  time = 3;
    public float time2;
    public float time3 = 18;
    // Start is called before the first frame update
    void Start()
    {
        time2 = time3;
    }

    // Update is called once per frame
    void Update()
    {    
        time -= Time.deltaTime;
        time3 = (time2 * time / 3);
    }
}
