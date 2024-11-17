using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb; //Rigidbody2D�̎擾
    GameManager gameM;�@//GameManager�̃X�N���v�g���擾
    public bool tmp = false;

    BulletBehind tmpColor;�@//�F�𑗂邽�߂̃X�N���v�g���擾

    [SerializeField]
    private GameObject ObjectColor; //�F��ς���I�u�W�F�N�g���擾

    [SerializeField]
    private float speed; //�e�̃X�s�[�h
    public float numBullet; //�e�̐���

    private int nBToText;//�e�L�X�g�\����̒e�̐���

    [SerializeField]
    private TextMeshProUGUI numText;�@//�e�L�X�g�̃R���|�[�l���g���擾

    public bool isRed = false;�@//�Ԃ������Ă��邩����
    public bool isGreen = false;�@//�΂������Ă��邩����
    public bool isBlue = false;�@//�������Ă��邩����
    

    float posY;

    public bool min;
    public bool mid;
    public bool max;

    public bool Bubble = false;
    public float BubbleCount = 0;
    public int  BubbleCount2 = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<BulletBehind>()) //�G�ꂽ�̂�Bullet�������Ƃ����s
        {
            
            collision.gameObject.GetComponent<BulletBehind>().tmpState(isRed, isGreen, isBlue, numBullet); //����Bullet�̐F�̏����A�G�ꂽBullet�ɑ���
           
            
        }

        else
        {
            return;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            //Vector2 force = new Vector2(0, -3);
            //rb.AddForce(force);
            //transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            ////numBullet -= 1;
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

        //numBullet = gameM.BulletNum;�@//�����̏���GameManager����󂯎��
    }

    void Update()
    {
        nBToText = Mathf.CeilToInt(numBullet);
        if(Bubble)
        {
            BubbleCount += 1 * Time.deltaTime;
            if (BubbleCount >= 1)
            {
                numBullet = numBullet * 1.3f;
                numBullet = Mathf.CeilToInt(numBullet);
                BubbleCount = 0;
                BubbleCount2++;
            }
            if (BubbleCount2 >= 10)
            {
                Destroy(this.gameObject);
            }
        }

        ThisColor();�@//�J���[�̕\��������
        numText.text = "" + nBToText;�@//�e�ɐ�����\��������

        if (this.gameObject.transform.position.y > 3.5f)
        {
            transform.position = new Vector2(transform.position.x,3.5f);
        }
        else
        {
            if (gameM.SpeedUpper)
            {
                rb.velocity = new Vector2(0, speed * 1.2f);
            }
            else
            {
                rb.velocity = new Vector2(0, speed);
            }
        }
        if (numBullet <= 0)
        {
            Destroy(this.gameObject);�@//�e�̐�����0�ɂȂ����������
        }
            
        
        if(numBullet <= 19 && !min) {

            transform.localScale = new Vector2(0.8f, 0.8f);
            if (mid)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
                mid = false;
            }
            if (max)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
                max = false;
            }          
            min = true;
        }else if (numBullet <= 31 && numBullet >= 20 && !mid)
        {
            transform.localScale = new Vector2(1f, 1f);
            posY = transform.position.y;
            if (max)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
                max = false;
            }else if (min)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
                min = false;
            }
            mid = true;

        }
        else if (numBullet >=32 && !max)
        {                
            transform.localScale = new Vector2(1.2f,1.2f);
            if (min)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y -0.2f);
                min = false;
            }
            if (mid)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
                mid = false;
            }
            max = true;
        }
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
    public void isDestroy()
    {
        Destroy(this.gameObject);
    }
    //private char calc(float num)
    //{
    //    char Text;

    //    return 
    //}
}
