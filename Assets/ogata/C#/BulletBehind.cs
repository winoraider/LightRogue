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
        gameM = FindObjectOfType<GameManager>();

        isRed2 = bullet.isRed;
        isGreen2 = bullet.isGreen;
        isBlue2 = bullet.isBlue;
    }
    // Update is called once per frame
    void Update()
    {
        GameObject objParent = transform.parent.gameObject;@//G‚ê‚½’e‚É‚É”š‚ğ“n‚·—p
        Bullet bullet = objParent.GetComponent<Bullet>();@//G‚ê‚½’e‚É‚É”š‚ğ“n‚·—p

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
        GameObject objParent = transform.parent.gameObject;@//G‚ê‚½’e‚É‚É”š‚ğ“n‚·—p
        Bullet bullet = objParent.GetComponent<Bullet>();@//G‚ê‚½’e‚É‚É”š‚ğ“n‚·—p

        if (isRed2 == _red && isGreen2 == _green && isBlue2 == _blue)
        {
            //Debug.Log("ŒÄ‚Ño‚µ");
            tmpN = _num;@//”š‚Ìî•ñ‚ğó‚¯æ‚é—p

            if (isRed2 == _red && !_green && !_blue)
            {
                tmpN += gameM.SingleAdd * gameM.RedAddPowLevel;
            }
            if (!_red && isGreen2 == _green && !_blue)
            {
                tmpN += gameM.SingleAdd * gameM.GreenAddPowLevel;
            }
            if (!_red && !_green && isBlue2 == _blue)
            {
                tmpN += gameM.SingleAdd * gameM.BlueAddPowLevel;
            }
            if (isRed2 == _red && isGreen2 ==_green && !_blue)
            {
                tmpN += gameM.DoubleAdd * gameM.YellowAddPowLevel;
            }
            if (!_red && isGreen2 == _green && isBlue2 ==_blue)
            {
                tmpN += gameM.DoubleAdd * gameM.CyanAddPowLevel;
            }
            if (isRed2 == _red && !_green && isBlue2 == _blue)
            {
                tmpN += gameM.DoubleAdd * gameM.MagentaAddPowLevel;
            }
            if (isRed2 == _red && isGreen == _green && isBlue2 == _blue)
            {
                tmpN += gameM.WhiteAdd * gameM.WhiteAddPowLevel;
            }
            tmpN += gameM.ALLPow * gameM.ALLPowLevel;
            tmpdeath = true;
            return;
        }

        if (isRed2 && _red && !isGreen2 && !_green && !isBlue2 && !_blue ||!isRed2 && !_red && isGreen2 && _green && !isBlue2 && !_blue ||!isRed2 && !_red && !isGreen2 && !_green && isBlue2 && _blue)
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

            

            if (!isRed2)
            {
                isRed2 = _red; //Ô‚Ìî•ñ‚ğó‚¯æ‚é—p
            }
            if (!isGreen2)
            {
                isGreen2 = _green;  //—Î‚Ìî•ñ‚ğó‚¯æ‚é—p
            }if (!isBlue2)
            {
                isBlue2 = _blue;
            }

            //Debug.Log(isRed2);
            //Debug.Log(isGreen2);
            //Debug.Log(isBlue2);

            if (isRed2 && isGreen2 && isBlue2)
            {
                bullet.numBullet *= tmpN + gameM.WhiteMag * gameM.WhiteMagPowLevel; //’e‚Ì”š‚Ìî•ñ‚ğ“n‚·
                //Debug.Log(bullet.numBullet);
                //Debug.Log(tmpN);
                tmpN = 0; //’e‚Ì’l‚ğ‰Šú‰»
            }
            else {
                bullet.numBullet += tmpN; //’e‚Ì”š‚Ìî•ñ‚ğ“n‚·
                if (isRed2 && isGreen2 && !isBlue2)
                {
                    bullet.numBullet *= gameM.mag2color + gameM.DoubleMag * gameM.YellowMagPowLevel;
                }
                if (isRed2 && !isGreen2 && isBlue2)
                {
                    bullet.numBullet *= gameM.mag2color + gameM.DoubleMag * gameM.MagentaMagPowLevel;
                }
                if (!isRed2 && isGreen2 && isBlue2)
                {
                    bullet.numBullet *= gameM.mag2color + gameM.DoubleMag * gameM.CyanMagPowLevel;
                }
                tmpN = 0; //’e‚Ì’l‚ğ‰Šú‰»
                bullet.numBullet=Mathf.CeilToInt(bullet.numBullet);
            }


                tmpdeath = true;
        }
    }

    public void tmpNum()
    {
        
    }
}
