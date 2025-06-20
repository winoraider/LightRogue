using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using TMPro;

public class EnemyNumController : MonoBehaviour
{
    [SerializeField] private float nowPower;
    public float NowPower
    {
        get { return this.nowPower; }
        set { this.nowPower = value;}
    }

    private int pToText;
    private float bossnowPower;
    public float BossNowPower
    {
        get { return this.bossnowPower; }
        set { this.bossnowPower = value; }
    }

    [SerializeField] private GameObject EXPPoint;
    public GameObject expPoint
    {
        get { return EXPPoint; }
        set { EXPPoint = value; }
    }

    [SerializeField] private ECardSpawn eCard;
    [SerializeField] TextMeshProUGUI normalenemyText;

    public void SetManager(ECardSpawn eCardSpawn)
    {
        this.eCard = eCardSpawn;
    }

    void Update()
    {
        pToText = Mathf.CeilToInt(nowPower);
        if (nowPower <= 0)
        {
            Instantiate(EXPPoint, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            eCard.ECount += -1;
            //Debug.Log("ecount -1 ");
        }

        normalenemyText.text = "" + pToText;
    }
}
