using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb; //Rigidbody2D�̎擾
    GameManager gameM;�@//GameManager�̃X�N���v�g���擾


    BulletBehind tmpColor;�@//�F�𑗂邽�߂̃X�N���v�g���擾

    [SerializeField]
    private GameObject ObjectColor; //�F��ς���I�u�W�F�N�g���擾

    [SerializeField]
    private float speed; //�e�̃X�s�[�h
    public float numBullet; //�e�̐���

    [SerializeField]
    private TextMeshProUGUI numText;�@//�e�L�X�g�̃R���|�[�l���g���擾

    public bool isRed = false;�@//�Ԃ������Ă��邩����
    public bool isGreen = false;�@//�΂������Ă��邩����
    public bool isBlue = false;�@//�������Ă��邩����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.GetComponent<BulletBehind>())�@//�G�ꂽ�̂�Bullet�������Ƃ����s
            {
            collision.gameObject.GetComponent<BulletBehind>().tmpNum(numBullet); //����Bullet�̐������A�G�ꂽBullet�ɑ���
            collision.gameObject.GetComponent<BulletBehind>().tmpColor(isRed,isGreen,isBlue);�@//����Bullet�̐F�̏����A�G�ꂽBullet�ɑ���
                Destroy(this.gameObject);�@//���̃I�u�W�F�N�g���폜����
            }

            
        
    }


    // Start is called before the first frame update
    void Start()
    {
        gameM = FindObjectOfType<GameManager>();�@//GameManager���Q�Ƃ���
        rb = GetComponent<Rigidbody2D>();�@//Rigidbody���Q�Ƃ���

        isRed = gameM.isRed;�@//�F�̏���GameManager����󂯎��
        isGreen = gameM.isGreen;�@//�F�̏���GameManager����󂯎��
        isBlue = gameM.isBlue;�@//�F�̏���GameManager����󂯎��

        numBullet = gameM.BulletNum;�@//�����̏���GameManager����󂯎��
    }

    void Update()
    {
        ThisColor();�@//�J���[�̕\��������
        numText.text = "" + numBullet;�@//�e�ɐ�����\��������


        if(numBullet <= 0)
        {
            Destroy(this.gameObject);�@//�e�̐�����0�ɂȂ����������
        }

        rb.velocity = new Vector2(0,speed);�@//�e�̓���
    }

    private void IsRed()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);�@//�ԕ\��
    }

    private void IsGreen()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);�@//�Ε\��
    }

    private void IsBlue()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);�@//�\��
    }

    private void IsYellow()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);�@//���\��
    }

    private void IsMagenta()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1);�@//�}�[���^�\��
    }
    private void IsCyan()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1, 1);�@//��F�\��
    }

    private void IsWhite()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);�@//���\��
    }

    private void ThisColor()
    {
        if (isRed && !isGreen && !isBlue)�@//�e�̐F�̏�񂪐Ԃ����������ꍇ
        {
            IsRed();�@//�e��Ԃɂ���
        }
        else if (!isRed && isGreen && !isBlue)�@//�e�̐F�̏�񂪗΂����������ꍇ
        {
            IsGreen();�@//�e��΂ɂ���
        }
        else if (!isRed && !isGreen && isBlue)�@//�e�̐F�̏�񂪐����������ꍇ
        {
            IsBlue(); //�e��ɂ���
        }
        else if (isRed && isGreen && !isBlue)�@//�e�̐F�̏�񂪐ԂƗ΂������ꍇ
        {
            IsYellow(); //�e�����ɂ���
        }
        else if (isRed && !isGreen && isBlue) //�e�̐F�̏�񂪐ԂƐ������ꍇ
        {
            IsMagenta(); //�e���}�[���^�ɂ���
        }
        else if (!isRed && isGreen && isBlue) //�e�̐F�̏�񂪗΂Ɛ������ꍇ
        {
            IsCyan(); //�e����F�ɂ���
        }
        else if (isRed && isGreen && isBlue) //�e�̐F�̏�񂪐ԁA�΁A�������Ă����ꍇ
        {
            IsWhite();�@//�e�̐F����ɂ���
        }
        else //�e�̐F�̏�񂪕s���������ꍇ
        {
            ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);�@//�e�̐F�����ɂ���
        }
    }
}
