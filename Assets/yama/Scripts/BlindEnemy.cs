using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindEnemy : MonoBehaviour
{
    bool toRed;
    bool toGreen;
    bool toBlue;
    bool killer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            Bullet b = collision.gameObject.GetComponent<Bullet>();
            if (toRed == b.isRed && toGreen == b.isGreen && toBlue == b.isGreen)
            {
                killer = true;
            }
        }
    }

    public bool Killer()
    {
        return killer;
    }
}
