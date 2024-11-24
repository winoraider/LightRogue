using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindEnemy : MonoBehaviour
{
    public bool toRed = false;
    public bool toGreen = false;
    public bool toBlue = false;

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
            //Debug.Log("ホワイト");
        }
        else if(!toRed && toGreen && toBlue)
        {
            //Debug.Log("シアン");
        }
        else if (toRed && !toGreen && toBlue)
        {
            //Debug.Log("マゼンタ");
        }
        else if (toRed && toGreen && !toBlue)
        {
            //Debug.Log("イエロー");
        }
        else if (!toRed && !toGreen && toBlue)
        {
            //Debug.Log("ブルー");
        }
        else if (toRed && !toGreen && !toBlue)
        {
            //Debug.Log("レッド");
        }
        else if (!toRed && toGreen && !toBlue)
        {
            //Debug.Log("グリーン");
        }
    }
}
