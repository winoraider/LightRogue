using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumController : MonoBehaviour
{
    bool hit = false;
    private float pPower;
    float counter = 0;
    [SerializeField] GameObject pBullet;
    private GameObject eBullet;
    public float biggerPower;
    Bullet bullet;

    public EnemyNumController enemyNumController;
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
                if (counter >= 1)//1秒たったら
                {
                    bullet.numBullet -= biggerPower / 3;
                    float nPower = enemyNumController.NowPower;
                    nPower -= biggerPower / 3;
                    bullet.numBullet = Mathf.CeilToInt(bullet.numBullet);
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
            Debug.Log("大きい方の数字" + biggerPower);
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
