using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class EnemyNumController : MonoBehaviour
{
    float counter;
    bool hit = false;
    [SerializeField] public float nowPower;
    public float comparePower;
    private string objName;
    NumController numController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nowPower <= 0)
        {
            Destroy(gameObject);
        }

        if (hit)
        {
            /*if (objName == "pCard")
            {
                counter += 1 * Time.deltaTime;
                if (counter >= 60)//1ïbÇΩÇ¡ÇΩÇÁ
                {
                    nowPower -= numController.biggerPower / 3;
                    counter = 0;
                    Debug.Log("ìGÅF" + nowPower);

                }
            }*/
        }
        else
        {
            transform.position += new Vector3(0, -1.0f, 0) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        comparePower = nowPower;
        objName = collision.gameObject.name;

        if(collision.gameObject.GetComponent<NumController>()) { 
        hit = true;
        }

        //GameObject obj = GameObject.Find(objName);
        //playerCard = obj.GetComponent<PlayerCard>();
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hit = false;
    }
}
