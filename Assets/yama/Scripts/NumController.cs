using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class NumController : MonoBehaviour
{
    bool hit = false;
    bool bosshit = false;
    private float pPower;
    float counter = 0;
    [SerializeField] GameObject pBullet;
    public float biggerPower;
    bool receiveTwice = false;//�_���[�W���{�󂯂邩�ǂ���
    Bullet bullet;

    private EnemyNumController enemyNumController;
    private BossEnemyNumController bossEnemyNumController;
    void Start()
    {
        bullet = GetComponent<Bullet>();
        pPower = bullet.numBullet;
        biggerPower = pPower;
    }
    void Update()
    {
        pPower = bullet.numBullet;
        if (pPower <= 0)
        {
            Destroy(gameObject);
        }

        if (hit)
        {
            counter += Time.deltaTime;
            if (counter >= 0.5f)//1�b��������
            {
                if (receiveTwice)//��{���炤
                {
                    bullet.numBullet -= biggerPower / 3 * 2;
                }
                else
                {
                    bullet.numBullet -= biggerPower / 3;
                }
                enemyNumController.NowPower -= biggerPower / 3;
                bullet.numBullet = Mathf.FloorToInt(bullet.numBullet);
                enemyNumController.NowPower = Mathf.FloorToInt(enemyNumController.NowPower);
                counter = 0;
            }
        }

        if(bosshit)
        {
            counter += Time.deltaTime;
            if (counter >= 0.5f)//1�b��������
            {
                bullet.numBullet -= biggerPower * Time.deltaTime;
                bullet.numBullet = Mathf.FloorToInt(bullet.numBullet);
                bossEnemyNumController.BossNowPower -= biggerPower * Time.deltaTime;
                bossEnemyNumController.BossNowPower = Mathf.FloorToInt(bossEnemyNumController.BossNowPower);
                counter = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyNumController>())//�G�ꂽ�I�u�W�F�N�g��EnemyNumController�̃R���|�[�l���g�������Ă�����
        {
            Debug.Log("�G�ɐG��܂���");
            enemyNumController = collision.gameObject.GetComponent<EnemyNumController>();
            hit = true;
            bosshit = false;
            if (pPower < enemyNumController.NowPower)//�ǂ������傫�������ׂ�
            {
                biggerPower = enemyNumController.NowPower;
            }
            else
            {
                biggerPower = pPower;
            }
        }

        if (collision.gameObject.GetComponent<BossEnemyNumController>())//�G�ꂽ�I�u�W�F�N�g��EnemyNumController�̃R���|�[�l���g�������Ă�����
        {
            Debug.Log("�G�ɐG��܂���");
            bossEnemyNumController = collision.gameObject.GetComponent<BossEnemyNumController>();
            hit = false;
            bosshit = true;
            if (pPower < bossEnemyNumController.BossNowPower)//�ǂ������傫�������ׂ�
            {
                biggerPower = bossEnemyNumController.BossNowPower;
            }
            else
            {
                biggerPower = pPower;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent <EnemyNumController>() || 
            collision.gameObject.GetComponent<BossEnemyNumController>())
        {

            Debug.Log("�Ă��ɂӂ�Ă��܂�");
        }
        if (collision.gameObject.GetComponent<BlindEnemy>())
        {
            receiveTwice = collision.gameObject.GetComponent<BlindEnemy>().Killer();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyNumController>() || collision.gameObject.GetComponent<BossEnemyNumController>())
        {
            hit = false;
            biggerPower = pPower;
            receiveTwice = false;
        }
    }
}