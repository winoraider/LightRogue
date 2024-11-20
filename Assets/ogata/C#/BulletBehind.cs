using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehind : MonoBehaviour
{
    Bullet bullet;�@//Bullet�̃X�N���v�g���Q��
    GameManager gameM;�@//GameManager�̃X�N���v�g���Q��

    [SerializeField]
    private GameObject deathObj;

    public bool isRed = false; //�Ԃ̏���e�ɓn���p
    public bool isGreen = false; //�΂̏���e�ɓn���p
    public bool isBlue = false; //�̏���e�ɓn���p

    public bool isRed2 = false;
    public bool isGreen2 = false;
    public bool isBlue2 = false;

    public float tmpN;�@//�����̏���e�ɓn���p

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
        GameObject objParent = transform.parent.gameObject;�@//�G�ꂽ�e�ɂɐ�����n���p
        Bullet bullet = objParent.GetComponent<Bullet>();�@//�G�ꂽ�e�ɂɐ�����n���p
        gameM = FindObjectOfType<GameManager>();

        isRed2 = bullet.isRed;
        isGreen2 = bullet.isGreen;
        isBlue2 = bullet.isBlue;
    }
    // Update is called once per frame
    void Update()
    {
        GameObject objParent = transform.parent.gameObject;�@//�G�ꂽ�e�ɂɐ�����n���p
        Bullet bullet = objParent.GetComponent<Bullet>();�@//�G�ꂽ�e�ɂɐ�����n���p

        if (isRed)
        {
            bullet.isRed = true; //�e�̐Ԃ̏���n��
        }
        if (isGreen)
        {
            bullet.isGreen = true; //�e�̗΂̏���n��
        }
        if (isBlue)
        {
            bullet.isBlue = true; //�e�̐̏���n��
        }
        if(tmpN != 0)
        {
            bullet.numBullet += tmpN; //�e�̐����̏���n��
            tmpN = 0;�@//�e�̒l��������
        }
        
    }

    public void tmpState(bool _red, bool _green, bool _blue, float _num)
    {
        GameObject objParent = transform.parent.gameObject;�@//�G�ꂽ�e�ɂɐ�����n���p
        Bullet bullet = objParent.GetComponent<Bullet>();�@//�G�ꂽ�e�ɂɐ�����n���p

        if (isRed2 == _red && isGreen2 == _green && isBlue2 == _blue)
        {
            //Debug.Log("�Ăяo��");
            tmpN = _num;�@//�����̏����󂯎��p

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
            tmpN = _num;�@//�����̏����󂯎��p
            tmpdeath = true;
        }

        if (!isRed2 && _red || !isGreen2 && _green || !isBlue2 && _blue)
        {
            isRed = _red; //�Ԃ̏����󂯎��p
            isGreen = _green;  //�΂̏����󂯎��p
            isBlue = _blue; //�̏����󂯎��p

            tmpN = _num;�@//�����̏����󂯎��p

            

            if (!isRed2)
            {
                isRed2 = _red; //�Ԃ̏����󂯎��p
            }
            if (!isGreen2)
            {
                isGreen2 = _green;  //�΂̏����󂯎��p
            }if (!isBlue2)
            {
                isBlue2 = _blue;
            }

            //Debug.Log(isRed2);
            //Debug.Log(isGreen2);
            //Debug.Log(isBlue2);

            if (isRed2 && isGreen2 && isBlue2)
            {
                bullet.numBullet *= tmpN + gameM.WhiteMag * gameM.WhiteMagPowLevel; //�e�̐����̏���n��
                //Debug.Log(bullet.numBullet);
                //Debug.Log(tmpN);
                tmpN = 0; //�e�̒l��������
            }
            else {
                bullet.numBullet += tmpN; //�e�̐����̏���n��
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
                tmpN = 0; //�e�̒l��������
                bullet.numBullet=Mathf.CeilToInt(bullet.numBullet);
            }


                tmpdeath = true;
        }
    }

    public void tmpNum()
    {
        
    }
}
