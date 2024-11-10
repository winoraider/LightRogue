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
    private float bossnowPower;
    public float BossNowPower
    {
        get { return this.bossnowPower; }
        set { this.bossnowPower = value; }
    }
    public float comparePower;
    private string objName;

    [SerializeField] private ECardSpawn eCard;

    [SerializeField] TextMeshProUGUI normalenemyText;
    [SerializeField] TextMeshProUGUI BossText;

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

        normalenemyText.text = "" + nowPower;
        BossText.text = "" + bossnowPower;
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
