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
            if (eBullet)
            {
                counter += 1;
                if (counter >= 120)//1秒たったら
                {
                    //Debug.Log("before" + enemyNumController.NowPower);
                    bullet.numBullet -= biggerPower / 3;
                    enemyNumController.NowPower -= biggerPower / 3;
                    //Debug.Log("after" + enemyNumController.NowPower);
                    bullet.numBullet = Mathf.FloorToInt(bullet.numBullet);
                    enemyNumController.NowPower = Mathf.FloorToInt(enemyNumController.NowPower);
                    counter = 0;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //EnemyNumController eNum;
        if(collision.gameObject.GetComponent<EnemyNumController>())//触れたオブジェクトがMoveEnemyのコンポーネントを持っていたら
        {
            enemyNumController = collision.gameObject.GetComponent<EnemyNumController>();
            hit = true;
            eBullet = collision.gameObject;

            if (pPower < enemyNumController.NowPower)
            {
                biggerPower = enemyNumController.NowPower;
            }
            else
            {
                biggerPower = pPower;
            }
            
            //Debug.Log("大きい方の数字" + biggerPower);
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
}