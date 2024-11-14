using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class NumController : MonoBehaviour
{
    private bool hit = false;
    bool hitNow = false;
    bool bosshit = false;
    private float pPower;
    [SerializeField] GameObject pBullet;
    public float biggerPower;
    bool receiveTwice = false;//�_���[�W���{�󂯂邩�ǂ���
    Bullet bullet;

    private EnemyNumController enemyNumController;
    private BossEnemyNumController bossEnemyNumController;

    GameObject aManager;
    AudioManager AudioManager;

    void Start()
    {
        bullet = GetComponent<Bullet>();
        pPower = bullet.numBullet;
        biggerPower = pPower;

        aManager = GameObject.Find("AudioManager");
        AudioManager = aManager.GetComponent<AudioManager>();
    }
    void Update()
    {
        pPower = bullet.numBullet;
        if (pPower <= 0)
        {
            AudioManager.BrokenPlay();
            Destroy(gameObject);
        }

        if (hit)
        {
            AudioManager.RedurcePlay();
            if (receiveTwice)//��{���炤
            {
                bullet.numBullet -= biggerPower * 2;
            }
            else
            {
                bullet.numBullet -= biggerPower / 3 * Time.deltaTime;
            }
            enemyNumController.NowPower -= biggerPower / 3 * Time.deltaTime;
        }

        if(bosshit)
        {
            AudioManager.RedurcePlay();
            bullet.numBullet -= biggerPower / 3 * Time.deltaTime;
            bossEnemyNumController.BossNowPower -= biggerPower / 3 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyNumController>())//�G�ꂽ�I�u�W�F�N�g��EnemyNumController�̃R���|�[�l���g�������Ă�����
        {
            Debug.Log("�G�ɐG��܂���");
            enemyNumController = collision.gameObject.GetComponent<EnemyNumController>();
            hit = true;
            hitNow = true;
            bosshit = false;
            if(pPower <= 30 && enemyNumController.NowPower <= 30)
            {
                biggerPower = 30;
            }
            else if (pPower < enemyNumController.NowPower)//�ǂ������傫�������ׂ�
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