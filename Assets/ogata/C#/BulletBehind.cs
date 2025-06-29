using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehind : MonoBehaviour
{
    Bullet bullet;　//Bulletのスクリプトを参照
    GameManager gameM;　//GameManagerのスクリプトを参照

    [SerializeField]
    private GameObject deathObj;

    public bool isRed = false; //赤の情報を弾に渡す用
    public bool isGreen = false; //緑の情報を弾に渡す用
    public bool isBlue = false; //青の情報を弾に渡す用

    public bool isRed2 = false;
    public bool isGreen2 = false;
    public bool isBlue2 = false;

    public float tmpN;　//数字の情報を弾に渡す用

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
        GameObject objParent = transform.parent.gameObject;　//触れた弾にに数字を渡す用
        Bullet bullet = objParent.GetComponent<Bullet>();　//触れた弾にに数字を渡す用
        gameM = FindObjectOfType<GameManager>();

        isRed2 = bullet.isRed;
        isGreen2 = bullet.isGreen;
        isBlue2 = bullet.isBlue;
    }
    // Update is called once per frame
    void Update()
    {
        GameObject objParent = transform.parent.gameObject;　//触れた弾にに数字を渡す用
        Bullet bullet = objParent.GetComponent<Bullet>();　//触れた弾にに数字を渡す用

        if (isRed)
        {
            bullet.isRed = true; //弾の赤の情報を渡す
        }
        if (isGreen)
        {
            bullet.isGreen = true; //弾の緑の情報を渡す
        }
        if (isBlue)
        {
            bullet.isBlue = true; //弾の青の情報を渡す
        }
        if(tmpN != 0)
        {
            bullet.numBullet += tmpN; //弾の数字の情報を渡す
            tmpN = 0;　//弾の値を初期化
        }
        
    }

    public void tmpState(bool _red, bool _green, bool _blue, float _num)
    {
        GameObject objParent = transform.parent.gameObject;　//触れた弾にに数字を渡す用
        Bullet bullet = objParent.GetComponent<Bullet>();　//触れた弾にに数字を渡す用

        if (isRed2 == _red && isGreen2 == _green && isBlue2 == _blue)
        {
            //Debug.Log("呼び出し");
            tmpN = _num;　//数字の情報を受け取る用

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
            tmpN = _num;　//数字の情報を受け取る用
            tmpdeath = true;
        }

        if (!isRed2 && _red || !isGreen2 && _green || !isBlue2 && _blue)
        {
            isRed = _red; //赤の情報を受け取る用
            isGreen = _green;  //緑の情報を受け取る用
            isBlue = _blue; //青の情報を受け取る用

            tmpN = _num;　//数字の情報を受け取る用

            

            if (!isRed2)
            {
                isRed2 = _red; //赤の情報を受け取る用
            }
            if (!isGreen2)
            {
                isGreen2 = _green;  //緑の情報を受け取る用
            }if (!isBlue2)
            {
                isBlue2 = _blue;
            }

            //Debug.Log(isRed2);
            //Debug.Log(isGreen2);
            //Debug.Log(isBlue2);

            if (isRed2 && isGreen2 && isBlue2)
            {
                bullet.numBullet *= tmpN + gameM.WhiteMag * gameM.WhiteMagPowLevel; //弾の数字の情報を渡す
                //Debug.Log(bullet.numBullet);
                //Debug.Log(tmpN);
                tmpN = 0; //弾の値を初期化
            }
            else {
                bullet.numBullet += tmpN; //弾の数字の情報を渡す
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
                tmpN = 0; //弾の値を初期化
                bullet.numBullet=Mathf.CeilToInt(bullet.numBullet);
            }


                tmpdeath = true;
        }
    }

    public void tmpNum()
    {
        
    }
}
