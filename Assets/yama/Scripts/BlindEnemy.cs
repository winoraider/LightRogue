using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindEnemy : MonoBehaviour
{
    public bool toRed = false;
    public bool toGreen = false;
    public bool toBlue = false;

    void Start()
    {
        toRed = Random.Range(0, 2) == 0;//toRed�AtoBlue�AtoGreen��true,false���ŏ��Ɍ��߂�
        toBlue = Random.Range(0, 2) == 0;
        toGreen = Random.Range(0, 2) == 0;
    }

    void Update()//���F�L���[���킩�点�邽�߂�UI�\��������
    {
        if(toRed &&  toGreen && toBlue)
        {
            //Debug.Log("�z���C�g");
        }
        else if(!toRed && toGreen && toBlue)
        {
            //Debug.Log("�V�A��");
        }
        else if (toRed && !toGreen && toBlue)
        {
            //Debug.Log("�}�[���^");
        }
        else if (toRed && toGreen && !toBlue)
        {
            //Debug.Log("�C�G���[");
        }
        else if (!toRed && !toGreen && toBlue)
        {
            //Debug.Log("�u���[");
        }
        else if (toRed && !toGreen && !toBlue)
        {
            //Debug.Log("���b�h");
        }
        else if (!toRed && toGreen && !toBlue)
        {
            //Debug.Log("�O���[��");
        }
    }
}
