using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class NumController : MonoBehaviour
{
    bool hit = false;
    private float pPower;
    float counter = 0;
    [SerializeField] GameObject pBullet;
    private GameObject eBullet;
    public float biggerPower;
    Bullet bullet;
    GameObject tRed;
    GameObject tGreen;
    GameObject tBlue;
    GameObject tCyan;
    GameObject tMagenta;
    GameObject tYellow;
    GameObject tWhite;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Bullet>();
        pPower = bullet.numBullet;
        biggerPower = pPower;
    }

    // Update is called once per frame
    void Update()
    {
        pPower = bullet.numBullet;
        if (pPower <= 0)
        {
            Destroy(gameObject);
        }

        if (hit)
        {
            if (eBullet)
            {
                counter += 1;
                if (counter >= 1)//1�b��������
                {
                    bullet.numBullet -= biggerPower / 3;
                    eBullet.GetComponent<EnemyNumController>().nowPower -= biggerPower / 3;
                    bullet.numBullet = Mathf.CeilToInt(bullet.numBullet);
                    counter = 0;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //EnemyNumController eNum;
        if(collision.gameObject.GetComponent<EnemyNumController>())//�G�ꂽ�I�u�W�F�N�g��MoveEnemy�̃R���|�[�l���g�������Ă�����
        {
            hit = true;
            eBullet = collision.gameObject;

            if (pPower < eBullet.GetComponent<EnemyNumController>().comparePower)
            {
                biggerPower = eBullet.GetComponent<EnemyNumController>().comparePower;
            }
            else
            {
                biggerPower = pPower;
            }
            Debug.Log("�傫�����̐���" + biggerPower);
        }
        //GameObject obj = GameObject.Find(objName);
        //moveEnemy = obj.GetComponent<MoveEnemy>();
        
        
        /*if(collision.gameObject.tag == "enemy")
        {
        
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hit = false;
        biggerPower = pPower;
    }

    private void ThisColor()
    {
        if (bullet.isRed && !bullet.isGreen && !bullet.isBlue)�@//�e�̐F�̏�񂪐Ԃ����������ꍇ
        {
            tRed.SetActive(true);
        }
        else if (!bullet.isRed && bullet.isGreen && !bullet.isBlue)�@//�e�̐F�̏�񂪗΂����������ꍇ
        {
            tGreen.SetActive(true);
        }
        else if (!bullet.isRed && !bullet.isGreen && bullet.isBlue)�@//�e�̐F�̏�񂪐����������ꍇ
        {
            tBlue.SetActive(true);
        }
        else if (bullet.isRed && bullet.isGreen && !bullet.isBlue)�@//�e�̐F�̏�񂪐ԂƗ΂������ꍇ
        {
            tMagenta.SetActive(true);
        }
        else if (bullet.isRed && !bullet.isGreen && bullet.isBlue) //�e�̐F�̏�񂪐ԂƐ������ꍇ
        {
            tYellow.SetActive(true);
        }
        else if (!bullet.isRed && bullet.isGreen && bullet.isBlue) //�e�̐F�̏�񂪗΂Ɛ������ꍇ
        {
            tCyan.SetActive(true);
        }
        else if (bullet.isRed && bullet.isGreen && bullet.isBlue) //�e�̐F�̏�񂪐ԁA�΁A�������Ă����ꍇ
        {
            tWhite.SetActive(true);
        }
        else //�e�̐F�̏�񂪕s���������ꍇ
        {
        }
    }
}