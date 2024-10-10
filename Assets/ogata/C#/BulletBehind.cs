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

        
    }
    // Update is called once per frame
    void Update()
    {
        GameObject objParent = transform.parent.gameObject;�@//�G�ꂽ�e�ɂɐ�����n���p
        Bullet bullet = objParent.GetComponent<Bullet>();�@//�G�ꂽ�e�ɂɐ�����n���p

        isRed2 = bullet.isRed;
        isGreen2 = bullet.isGreen;
        isBlue2 = bullet.isBlue;

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

        if(isRed2 && _red && !isGreen2 && !_green && !isBlue2 && !_blue ||!isRed2 && !_red && isGreen2 && _green && !isBlue2 && !_blue ||!isRed2 && !_red && !isGreen2 && !_green && isBlue2 && _blue)
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

            tmpdeath = true;
        }
    }

    public void tmpNum()
    {
        
    }
}
