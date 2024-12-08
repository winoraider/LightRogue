using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlindEnemy : MonoBehaviour
{

    [SerializeField] GameObject ColorCircle;
    public bool toRed = false;
    public bool toGreen = false;
    public bool toBlue = false;

    void Start()
    {
        while (toBlue == false && toRed == false && toGreen == false)
        {
            toRed = Random.Range(0, 2) == 0;//toRed�AtoBlue�AtoGreen��true,false���ŏ��Ɍ��߂�
            toBlue = Random.Range(0, 2) == 0;
            toGreen = Random.Range(0, 2) == 0;
        }
    }

    void Update()//���F�L���[���킩�点�邽�߂�UI�\��������
    {
        if(toRed &&  toGreen && toBlue)
        {
            this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);�@//�ԕ\��
        }
        else if(!toRed && toGreen && toBlue)
        {
            this.gameObject.GetComponent<Image>().color = new Color(0, 1, 1, 1);�@//�ԕ\��
        }
        else if (toRed && !toGreen && toBlue)
        {
            this.gameObject.GetComponent<Image>().color = new Color(1, 0, 1, 1);�@//�ԕ\��
        }
        else if (toRed && toGreen && !toBlue)
        {
            this.gameObject.GetComponent<Image>().color = new Color(1, 1, 0, 1);�@//�ԕ\��
        }
        else if (!toRed && !toGreen && toBlue)
        {
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 1, 1);�@//�ԕ\��
        }
        else if (toRed && !toGreen && !toBlue)
        {
            this.gameObject.GetComponent<Image>().color = new Color(1, 0, 0, 1);�@//�ԕ\��
        }
        else if (!toRed && toGreen && !toBlue)
        {
            this.gameObject.GetComponent<Image>().color = new Color(0, 1, 0, 1);�@//�ԕ\��
        }
    }
}
