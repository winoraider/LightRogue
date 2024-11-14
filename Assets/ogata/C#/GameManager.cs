using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float BulletNum; //カードから弾に送るための数字の情報

    EnemyNumController enemy;

    [SerializeField]
    public float NeedEXP;
    [SerializeField]
    public float AddNeedEXP;
    [SerializeField]
    public float PlayerLevel;

    [SerializeField]
    public float SinglePow;
    [SerializeField]
    public float ALLPow;
    [SerializeField]
    public float SingleAdd;
    [SerializeField]
    public float DoubleAdd;
    [SerializeField]
    public float DoubleMag;
    [SerializeField]
    public float WhiteMag;
    [SerializeField]
    public float WhiteAdd;

    [SerializeField]
    public int RedPowLevel;
    [SerializeField]
    public int GreenPowLevel;
    [SerializeField]
    public int BluePowLevel;
    [SerializeField]
    public float ALLPowLevel;
    [SerializeField]
    public int RedAddPowLevel;
    [SerializeField]
    public int GreenAddPowLevel;
    [SerializeField]
    public int BlueAddPowLevel;
    [SerializeField]
    public int YellowAddPowLevel;
    [SerializeField]
    public int MagentaAddPowLevel;
    [SerializeField]
    public int CyanAddPowLevel;
    [SerializeField]
    public int YellowMagPowLevel;
    [SerializeField]
    public int MagentaMagPowLevel;
    [SerializeField]
    public int CyanMagPowLevel;
    [SerializeField]
    public float WhiteMagPowLevel;
    [SerializeField]
    public float WhiteAddPowLevel;
    [SerializeField]
    public bool SpeedUpper = false;
    [SerializeField]
    public bool LevelUpper = false;
    [SerializeField]
    public bool SlowStarter = false;

    

    [SerializeField]
    public float RedCardAdd;
    [SerializeField]
    public float GreenCardAdd;
    [SerializeField]
    public float BlueCardAdd;

    public int RedWidePrism = 0;
    public int GreenWidePrism = 0;
    public int BlueWidePrism = 0;

    public int RedUpPrism = 0;
    public int GreenUpPrism = 0;
    public int BlueUpPrism = 0;

    public bool RedCountSensor;
    public bool GreenCountSensor;
    public bool BlueCountSensor;

    public int RedCount;
    public int GreenCount;
    public int BlueCount;
    public int YellowCount;
    public int MagentaCount;
    public int CyanCount;
    public int WhiteCount;

    public bool SlowTimer = false;
    private float Slowcount;

    public bool WindBoom;
    public int WindBoomcount;
    public bool KnockBack;
    private float Knockbackcount;

    public bool flash;
    [SerializeField]
    private float flashcount;

    public bool isRed;　//カードから弾に送るための赤の情報
    public bool isGreen;　//カードから弾に送るための緑の情報
    public bool isBlue;　//カードから弾に送るための青の情報

    public float mag2color; //二色倍率
    public float mag3color; //三色倍率

    [SerializeField]
    private GameObject RelicObject;
    public GameObject RelicOb
    {
        get { return RelicObject; }
        set { RelicObject = value; }
    }

    EnemyNumController[] Enemys;
    BossEnemyNumController Boss;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            RelicObject.SetActive(true);
        }
        if (SlowTimer)
        {
            Slowcount += Time.deltaTime;
            if(Slowcount >= 5)
            {
                Slowcount = 0;
                SlowTimer = false;
            }
        }
        
        if (KnockBack)
        {
            Knockbackcount += Time.deltaTime;
            if(Knockbackcount >= 0.2)
            {
                Knockbackcount = 0;
                KnockBack = false;
            }
        }
        if (flash)
        {
            flashcount -= Time.deltaTime;
            if(flashcount <= 0)
            {
                flashcount = 30;
                Enemys = FindObjectsOfType<EnemyNumController>();
                
                    Boss = FindObjectOfType<BossEnemyNumController>();
                if (Boss != null)
                {
                    Boss.BossNowPower -= 100;
                }
                
                for(int i = 0; i < Enemys.Length; i++)
                {
                    Enemys[i].NowPower -= 100;
                }

            }
        }
    }

}
