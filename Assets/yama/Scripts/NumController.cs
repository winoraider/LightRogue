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
    public float biggerPower;
    bool receiveTwice = false;//�_���[�W���{�󂯂邩�ǂ���
    Bullet bullet;

    private EnemyNumController enemyNumController;

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
            counter += 1;
            if (counter >= 120)//1�b��������
            {
                if (receiveTwice)//��{���炤
                {
                    bullet.numBullet -= biggerPower / 3 * 2;
                }
                else
                {
                    bullet.numBullet -= biggerPower / 3;
                }
                //Debug.Log("before" + enemyNumController.NowPower);
                enemyNumController.NowPower -= biggerPower / 3;
                //Debug.Log("after" + enemyNumController.NowPower);
                bullet.numBullet = Mathf.FloorToInt(bullet.numBullet);
                enemyNumController.NowPower = Mathf.FloorToInt(enemyNumController.NowPower);
                counter = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //EnemyNumController eNum;
        if(collision.gameObject.GetComponent<EnemyNumController>())//�G�ꂽ�I�u�W�F�N�g��MoveEnemy�̃R���|�[�l���g�������Ă�����
        {
            enemyNumController = collision.gameObject.GetComponent<EnemyNumController>();
            hit = true;
            if (pPower < enemyNumController.NowPower)
            {
                biggerPower = enemyNumController.NowPower;
            }
            else
            {
                biggerPower = pPower;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BlindEnemy>())
        {
            receiveTwice = collision.gameObject.GetComponent<BlindEnemy>().Killer();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hit = false;
        biggerPower = pPower;
        receiveTwice = false;
    }
}