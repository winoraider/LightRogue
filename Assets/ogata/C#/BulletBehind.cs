using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehind : MonoBehaviour
{
    Bullet bullet;　//Bulletのスクリプトを参照
    GameManager gameM;　//GameManagerのスクリプトを参照

    public bool isRed = false; //赤の情報を弾に渡す用
    public bool isGreen = false; //緑の情報を弾に渡す用
    public bool isBlue = false; //青の情報を弾に渡す用

    public float tmpN;　//数字の情報を弾に渡す用

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

    public void tmpColor(bool _red,bool _green,bool _blue)
    {
        isRed = _red; //赤の情報を受け取る用
        isGreen = _green;  //緑の情報を受け取る用
        isBlue = _blue; //青の情報を受け取る用
    }

    public void tmpNum(float _num)
    {
        tmpN = _num;　//数字の情報を受け取る用
    }
}
