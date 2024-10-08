using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehind : MonoBehaviour
{
    Bullet bullet;�@//Bullet�̃X�N���v�g���Q��
    GameManager gameM;�@//GameManager�̃X�N���v�g���Q��

    public bool isRed = false; //�Ԃ̏���e�ɓn���p
    public bool isGreen = false; //�΂̏���e�ɓn���p
    public bool isBlue = false; //�̏���e�ɓn���p

    public float tmpN;�@//�����̏���e�ɓn���p

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

    public void tmpColor(bool _red,bool _green,bool _blue)
    {
        isRed = _red; //�Ԃ̏����󂯎��p
        isGreen = _green;  //�΂̏����󂯎��p
        isBlue = _blue; //�̏����󂯎��p
    }

    public void tmpNum(float _num)
    {
        tmpN = _num;�@//�����̏����󂯎��p
    }
}
