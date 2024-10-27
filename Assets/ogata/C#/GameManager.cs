using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float BulletNum; //カードから弾に送るための数字の情報

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



    public bool isRed;　//カードから弾に送るための赤の情報
    public bool isGreen;　//カードから弾に送るための緑の情報
    public bool isBlue;　//カードから弾に送るための青の情報

    public float mag2color; //二色倍率
    public float mag3color; //三色倍率

   


}
