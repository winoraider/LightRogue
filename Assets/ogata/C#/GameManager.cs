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
    public int ColorLevel;
    [SerializeField]
    public int CardLevel;
    [SerializeField]
    public int HpLevel;

    public bool isRed;�@//�J�[�h����e�ɑ��邽�߂̐Ԃ̏��
    public bool isGreen;�@//�J�[�h����e�ɑ��邽�߂̗΂̏��
    public bool isBlue;�@//�J�[�h����e�ɑ��邽�߂̐̏��

    public float mag2color; //��F�{��
    public float mag3color; //�O�F�{��

}
