using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    bool hit = false;
    [SerializeField] int pPower;
    float counter = 0;
    private string objName;
    public int biggerPower;
    // Start is called before the first frame update
    void Start()
    {
        biggerPower = pPower;
    }

    // Update is called once per frame
    void Update()
    {
        if (pPower <= 0)
        {
            //Destroy(gameObject);
        }

        if (hit)
        {
            if(objName == "enemy")
            {
                counter += 1 * Time.deltaTime;
                if (counter >= 60)//1秒たったら
                {
                    pPower -= biggerPower / 3;
                    counter = 0;
                    Debug.Log("プレイヤー：" + pPower);
                }
            }
        }
        else
        {
            transform.position += new Vector3(0, 1.0f, 0) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        objName = collision.gameObject.name;
        if(collision.gameObject.GetComponent<MoveEnemy>())//触れたオブジェクトがMoveEnemyのコンポーネントを持っていたら
        {
            hit = true;

            if (pPower < collision.gameObject.GetComponent<MoveEnemy>().comparePower)
            {
                biggerPower = collision.gameObject.GetComponent<MoveEnemy>().comparePower;
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
        objName = "";
        hit = false;
        biggerPower = pPower;
    }
}
