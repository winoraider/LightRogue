using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float BulletNum; //�J�[�h����e�ɑ��邽�߂̐����̏��

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



    public bool isRed;�@//�J�[�h����e�ɑ��邽�߂̐Ԃ̏��
    public bool isGreen;�@//�J�[�h����e�ɑ��邽�߂̗΂̏��
    public bool isBlue;�@//�J�[�h����e�ɑ��邽�߂̐̏��

    public float mag2color; //��F�{��
    public float mag3color; //�O�F�{��

}
