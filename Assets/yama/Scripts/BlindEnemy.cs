using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindEnemy : MonoBehaviour
{
    bool toRed = false;
    bool toGreen = false;
    bool toBlue = false;
    bool killer = false;

    void Start()
    {
        toRed = Random.Range(0, 2) == 0;//toRed、toBlue、toGreenのtrue,falseを最初に決める
        toBlue = Random.Range(0, 2) == 0;
        toGreen = Random.Range(0, 2) == 0;
    }

    void Update()//何色キラーかわからせるためのUI表示をする
    {
        if(toRed &&  toGreen && toBlue)
        {

        }
        else if(!toRed && toGreen && toBlue)
        {

        }
        else if (toRed && !toGreen && toBlue)
        {

        }
        else if (toRed && toGreen && !toBlue)
        {

        }
        else if (!toRed && !toGreen && toBlue)
        {

        }
        else if (toRed && !toGreen && !toBlue)
        {

        }
        else if (!toRed && !toGreen && !toBlue)
        {

        }
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
