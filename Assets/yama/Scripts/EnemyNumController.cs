using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using TMPro;

public class EnemyNumController : MonoBehaviour
{
    float counter;
    bool hit = false;

    private float nowPower;
    public float NowPower
    {
        get { return this.nowPower; }
        set { this.nowPower = value;}
    }
    public float comparePower;
    private string objName;

    [SerializeField] private ECardSpawn eCard;

    [SerializeField] TextMeshProUGUI normalenemyText;

    public void SetManager(ECardSpawn eCardSpawn)
    {
        this.eCard = eCardSpawn;
    }

    void Update()
    {
        if (nowPower <= 0f)
        {
            Destroy(gameObject);
            eCard.ECount += -1;
            Debug.Log("ecount -1 ");
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

        normalenemyText.text = "" + nowPower;
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
