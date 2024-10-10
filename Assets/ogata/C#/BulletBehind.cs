using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehind : MonoBehaviour
{
    Bullet bullet;@//Bullet‚ÌƒXƒNƒŠƒvƒg‚ğQÆ
    GameManager gameM;@//GameManager‚ÌƒXƒNƒŠƒvƒg‚ğQÆ

    [SerializeField]
    private GameObject deathObj;

    public bool isRed = false; //Ô‚Ìî•ñ‚ğ’e‚É“n‚·—p
    public bool isGreen = false; //—Î‚Ìî•ñ‚ğ’e‚É“n‚·—p
    public bool isBlue = false; //Â‚Ìî•ñ‚ğ’e‚É“n‚·—p

    public bool isRed2 = false;
    public bool isGreen2 = false;
    public bool isBlue2 = false;

    public float tmpN;@//”š‚Ìî•ñ‚ğ’e‚É“n‚·—p

    bool tmpdeath  = false;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((tmpdeath))
        {
            Destroy(collision.gameObject);
            tmpdeath = false;
        }
        
    }

    private void Start()
    {
        GameObject objParent = transform.parent.gameObject;@//G‚ê‚½’e‚É‚É”š‚ğ“n‚·—p
        Bullet bullet = objParent.GetComponent<Bullet>();@//G‚ê‚½’e‚É‚É”š‚ğ“n‚·—p

        
    }
    // Update is called once per frame
    void Update()
    {
        GameObject objParent = transform.parent.gameObject;@//G‚ê‚½’e‚É‚É”š‚ğ“n‚·—p
        Bullet bullet = objParent.GetComponent<Bullet>();@//G‚ê‚½’e‚É‚É”š‚ğ“n‚·—p

        isRed2 = bullet.isRed;
        isGreen2 = bullet.isGreen;
        isBlue2 = bullet.isBlue;

        if (isRed)
        {
            bullet.isRed = true; //’e‚ÌÔ‚Ìî•ñ‚ğ“n‚·
        }
        if (isGreen)
        {
            bullet.isGreen = true; //’e‚Ì—Î‚Ìî•ñ‚ğ“n‚·
        }
        if (isBlue)
        {
            bullet.isBlue = true; //’e‚ÌÂ‚Ìî•ñ‚ğ“n‚·
        }
        if(tmpN != 0)
        {
            bullet.numBullet += tmpN; //’e‚Ì”š‚Ìî•ñ‚ğ“n‚·
            tmpN = 0;@//’e‚Ì’l‚ğ‰Šú‰»
        }
        
    }

    public void tmpState(bool _red, bool _green, bool _blue, float _num)
    {

        if(isRed2 && _red && !isGreen2 && !_green && !isBlue2 && !_blue ||!isRed2 && !_red && isGreen2 && _green && !isBlue2 && !_blue ||!isRed2 && !_red && !isGreen2 && !_green && isBlue2 && _blue)
        {
            tmpN = _num;@//”š‚Ìî•ñ‚ğó‚¯æ‚é—p
            tmpdeath = true;
        }

        if (!isRed2 && _red || !isGreen2 && _green || !isBlue2 && _blue)
        {
            isRed = _red; //Ô‚Ìî•ñ‚ğó‚¯æ‚é—p
            isGreen = _green;  //—Î‚Ìî•ñ‚ğó‚¯æ‚é—p
            isBlue = _blue; //Â‚Ìî•ñ‚ğó‚¯æ‚é—p

            tmpN = _num;@//”š‚Ìî•ñ‚ğó‚¯æ‚é—p

            tmpdeath = true;
        }
    }

    public void tmpNum()
    {
        
    }
}
