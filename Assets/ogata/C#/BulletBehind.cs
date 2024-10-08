using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehind : MonoBehaviour
{
    Bullet bullet;
    GameManager gameM;

    public bool isRed = false;
    public bool isGreen = false;
    public bool isBlue = false;

    public float tmpN;

    // Update is called once per frame
    void Update()
    {
        GameObject objParent = transform.parent.gameObject;
        Bullet bullet = objParent.GetComponent<Bullet>();

        if (isRed)
        {
            bullet.isRed = true;
        }
        if (isGreen)
        {
            bullet.isGreen = true;
        }
        if (isBlue)
        {
            bullet.isBlue = true;
        }
        if(tmpN != 0)
        {
            bullet.numBullet += tmpN;
            tmpN = 0;
        }
    }

    public void tmpColor(bool _red,bool _green,bool _blue)
    {
        isRed = _red; 
        isGreen = _green; 
        isBlue = _blue;
    }

    public void tmpNum(float _num)
    {
        tmpN = _num;
    }
}
