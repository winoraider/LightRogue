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
    bool receiveTwice = false;//ダメージを二倍受けるかどうか
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
            if (counter >= 0.5f)//1秒たったら
            {
                if (receiveTwice)//二倍くらう
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
            if (counter >= 0.5f)//1秒たったら
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
        if(collision.gameObject.GetComponent<EnemyNumController>())//触れたオブジェクトがEnemyNumControllerのコンポーネントを持っていたら
        {
            Debug.Log("敵に触れました");
            enemyNumController = collision.gameObject.GetComponent<EnemyNumController>();
            hit = true;
            bosshit = false;
            if (pPower < enemyNumController.NowPower)//どっちが大きいかを比べる
            {
                biggerPower = enemyNumController.NowPower;
            }
            else
            {
                biggerPower = pPower;
            }
        }

        if (collision.gameObject.GetComponent<BossEnemyNumController>())//触れたオブジェクトがEnemyNumControllerのコンポーネントを持っていたら
        {
            Debug.Log("敵に触れました");
            bossEnemyNumController = collision.gameObject.GetComponent<BossEnemyNumController>();
            hit = false;
            bosshit = true;
            if (pPower < bossEnemyNumController.BossNowPower)//どっちが大きいかを比べる
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

            Debug.Log("てきにふれています");
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