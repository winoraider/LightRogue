using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int numBullet; //’e‚Ì”š
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numBullet <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
