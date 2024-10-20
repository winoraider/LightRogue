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



    public bool isRed;　//カードから弾に送るための赤の情報
    public bool isGreen;　//カードから弾に送るための緑の情報
    public bool isBlue;　//カードから弾に送るための青の情報

    public float mag2color; //二色倍率
    public float mag3color; //三色倍率

}
