using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

public class Card : MonoBehaviour
{
    GameManager gameM;�@//GameManager�̃X�N���v�g���Q��
    CardSpawner cardspaw;

    [SerializeField]
    public float num; //�J�[�h�̐���
    //public int SendNum; //�J�[�h�̏��𑗂�p

    private Vector2 findpos; //��[���ꂽ�J�[�h�̍ŏ��̈ʒu

    [SerializeField]
    private GameObject ObjectColor;�@//�J�[�h�̐F�̏��𑗂�p

    private bool leftMouseKey = false;�@//�}�E�X�̍��L�[��������Ă��邩�̔���
    [SerializeField]
    private GameObject bullet; //�e���C���X�^���X����p

    [SerializeField]
    private GameObject BattleLane_01;�@//01���[���̏��
    [SerializeField]
    private GameObject BattleLane_02;  //02���[���̏��
    [SerializeField]
    private GameObject BattleLane_03;�@//03���[���̏��

    [SerializeField] 
    private GameObject Spawner_01;�@//�e�̃X�|�[���ꏊ�̐ݒ�i01���[���j
    [SerializeField]
    private GameObject Spawner_02;�@//�e�̃X�|�[���ꏊ�̐ݒ�i02���[���j
    [SerializeField]
    private GameObject Spawner_03; //�e�̃X�|�[���ꏊ�̐ݒ�i03���[���j

    [SerializeField]
    private TextMeshProUGUI numText; // TextMeshPro�̎擾

    [SerializeField]
    private bool Lane_01 = false;�@//01���[���ɐG��Ă��邩�̔���p
    [SerializeField]
    private bool Lane_02 = false;�@//02���[���ɐG��Ă��邩�̔���p
    [SerializeField]
    private bool Lane_03 = false;�@//03���[���ɐG��Ă��邩�̔���p

    Vector2 MousePos; //�J�[�\���L�[�̏ꏊ�̎擾�p

    public bool isRed = false;�@//�J�[�h�̐F����
    public bool isGreen = false;�@//�J�[�h�̐F����
    public bool isBlue = false;�@//�J�[�h�̐F����

    public bool pos01card = false;�@//���̈ʒu�ɂ���
    public bool pos02card = false;�@//�^�񒆂̈ʒu�ɂ���
    public bool pos03card = false;�@//�E�̈ʒu�ɂ���

    public bool Bubble = false;

    private GameObject BulletObject;

    [SerializeField]
    private GameObject CoolDown;



    public Card(bool _red, bool _green, bool _blue){�@//�J�[�h�̐F��ݒ肷��p

        isRed = _red; //�Ԃ�ݒ肷��p
        isGreen = _green;�@//�΂�ݒ肷��p
        isBlue = _blue;�@//��ݒ肷��p
    }



    private void OnTriggerStay2D(Collider2D collision)�@//�J�[�h�����[���ɐG��Ă���ԗp
    {

            if (collision.gameObject.name == "BattleLane_01")�@//�J�[�h��01���[���ɐG�ꂽ�Ƃ�
            {
                Lane_01 = true;
                Lane_02 = false;
                Lane_03 = false;
            }
            else if (collision.gameObject.name == "BattleLane_02") //�J�[�h��02���[���ɐG�ꂽ�Ƃ�
            {
                Lane_01 = false;
                Lane_02 = true ;
                Lane_03 = false;
            }
            else if (collision.gameObject.name == "BattleLane_03")�@//�J�[�h��03���[���ɐG�ꂽ�Ƃ�
            {
                Lane_01 = false;
                Lane_02 = false;
                Lane_03 = true;
            }
        
    }
    private void OnTriggerExit2D(Collider2D collision) //�J�[�h�����[�����痣�ꂽ���p
    {
        if (collision.gameObject.name == "BattleLane_01")�@//�J�[�h��01���[�����痣�ꂽ�Ƃ�
        {
            Lane_01 = false;
        }
        else if (collision.gameObject.name == "BattleLane_02")�@//�J�[�h��02���[�����痣�ꂽ�Ƃ�
        {
            Lane_02 = false;
        }
        else if (collision.gameObject.name == "BattleLane_03")�@//�J�[�h��03���[�����痣�ꂽ�Ƃ�
        {
            Lane_03 = false;
        }
    }

    void Start()
    {
        gameM = GameObject.FindObjectOfType<GameManager>(); //GameManager�̎擾
        cardspaw = GameObject.FindObjectOfType<CardSpawner>(); //CardSpawner�̎擾
        findpos = transform.position;
        if (isRed)
        {
            num += gameM.SinglePow * gameM.RedPowLevel;
        }
        if (isBlue)
        {
            num += gameM.SinglePow * gameM.BluePowLevel;
        }
        if (isGreen)
        {
            num += gameM.SinglePow * gameM.GreenPowLevel;
        }

        num += gameM.ALLPow * gameM.ALLPowLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (Bubble)
        {

        }
        ThisColor();�@//�J�[�h�̐F�̕\��
        numText.text = ""+num;�@//�������J�[�h�ɕ\��

        if (leftMouseKey)�@//�}�E�X�̍��L�[��������Ă���Ƃ�
        {
            Vector2 tmpPos = Input.mousePosition;�@//�}�E�X�J�[�\���̈ʒu��tmpPos�ɑ��
            MousePos = Camera.main.ScreenToWorldPoint(tmpPos);�@//tmpPos���g���āA�}�E�X�J�[�\���̈ʒu��Unity�̃J�����ɑΉ�������
            transform.position = MousePos; //�J�[�h�̈ʒu���}�E�X�J�[�\���̈ʒu�Ɠ���������
        }

        if (Input.GetMouseButtonUp(0)&& leftMouseKey)�@//�}�E�X�̍��L�[�𗣂����Ƃ�
        {
            leftMouseKey = false;�@//���L�[�̏���������Ă��Ȃ���Ԃɂ���
        }


    }

    private void OnMouseDown()�@//�J�[�h��I�����āA�}�E�X�̃L�[���������Ƃ�
    {
        if (Input.GetMouseButtonDown(0))�@//�}�E�X�̍��L�[��������
        {
            leftMouseKey = true;�@//�}�E�X�̍��L�[��������Ă����Ԃɂ���
        }
    }

    private void OnMouseUp() //�}�E�X�̃L�[�𗣂�����
    {
        if (Input.GetMouseButtonUp(0) && leftMouseKey)�@//�}�E�X�̍��L�[�𗣂����Ƃ�
        {
            gameM.BulletNum = num; //�J�[�h�̏���GameManager�ɑ���
            leftMouseKey = false;�@//�}�E�X�̍��L�[��������Ă��Ȃ���Ԃɂ���

            gameM.isRed = isRed; //�J�[�h�̐Ԃ̏���GameManager�ɑ���
            gameM.isGreen = isGreen;�@//�J�[�h�̗΂̏���GameManager�ɑ���
            gameM.isBlue = isBlue;�@//�J�[�h�̐̏���GameManager�ɑ���

            if (Lane_01 || Lane_02 || Lane_03)
            {
                if (pos01card)
                {
                    cardspaw.pos01card = false;
                    pos01card = false;
                }
                if (pos02card)
                {
                    cardspaw.pos02card = false;
                    pos02card = false;
                }
                if (pos03card)
                {
                    cardspaw.pos03card = false;
                    pos03card = false;
                }
                if (gameM.WindBoom)
                {
                    gameM.WindBoomcount++;
                    if(gameM.WindBoomcount >= 20)
                    {
                        gameM.KnockBack = true;
                    }
                }
                Instantiate(CoolDown, findpos, Quaternion.identity);
            }
            else
            {
                transform.position = findpos;
            }

            if (Lane_01)�@//01���[���ō��L�[�𗣂����Ƃ�
            {
                if (gameM.RedCountSensor || gameM.GreenCountSensor || gameM.BlueCountSensor)
                {
                    if (isRed) gameM.RedCount++;
                    if (isGreen) gameM.GreenCount++;
                    if (isBlue) gameM.BlueCount++;

                    if (gameM.RedCount == 5)
                    {
                        num *= 2;
                        gameM.RedCount = 0;
                    }
                    if (gameM.GreenCount == 5)
                    {
                        num *= 2;
                        gameM.GreenCount = 0;
                    }
                    if (gameM.BlueCount == 5)
                    {
                        num *= 2;
                        gameM.BlueCount = 0;
                    }
                }
                if (isRed && gameM.RedUpPrism == 1 && gameM.RedWidePrism == 1 || isGreen && gameM.GreenUpPrism == 1 && gameM.GreenWidePrism == 1 || isBlue && gameM.BlueUpPrism == 1 && gameM.BlueWidePrism == 1)
                {
                    num = num / 4;
                    num = Mathf.CeilToInt(num);
                    BulletObject = Instantiate(bullet, Spawner_01.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, new Vector2(Spawner_01.transform.position.x, Spawner_01.transform.position.y + 1f), Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, Spawner_02.transform.position, Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, new Vector2(Spawner_02.transform.position.x, Spawner_02.transform.position.y + 1f), Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                }
                else if (isRed && gameM.RedUpPrism == 1 || isGreen && gameM.GreenUpPrism == 1 || isBlue && gameM.BlueUpPrism == 1)
                {
                    num = num / 2;
                    num = Mathf.CeilToInt(num);
                    BulletObject = Instantiate(bullet, Spawner_01.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, new Vector2 (Spawner_01.transform.position.x , Spawner_01.transform.position.y + 1f), Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                }
               
                else if(isRed && gameM.RedWidePrism == 1 || isGreen && gameM.GreenWidePrism == 1 || isBlue�@&& gameM.BlueWidePrism == 1)
                {
                    num = num / 2;
                    num = Mathf.CeilToInt(num);
                    BulletObject = Instantiate(bullet, Spawner_01.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, Spawner_02.transform.position, Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;

                }
                else {
                    BulletObject = Instantiate(bullet, Spawner_01.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                }
                
                Destroy(this.gameObject);�@//�J�[�h������
            }
            else if (Lane_02)�@//02���[���ō��L�[�𗣂����Ƃ�
            {
                if (gameM.RedCountSensor || gameM.GreenCountSensor || gameM.BlueCountSensor)
                {
                    if (isRed) gameM.RedCount++;
                    if (isGreen) gameM.GreenCount++;
                    if (isBlue) gameM.BlueCount++;

                    if (gameM.RedCount == 5)
                    {
                        num *= 2;
                        gameM.RedCount = 0;
                    }
                    if (gameM.GreenCount == 5)
                    {
                        num *= 2;
                        gameM.GreenCount = 0;
                    }
                    if (gameM.BlueCount == 5)
                    {
                        num *= 2;
                        gameM.BlueCount = 0;
                    }
                }
                if (isRed && gameM.RedUpPrism == 1 && gameM.RedWidePrism == 1 || isGreen && gameM.GreenUpPrism == 1 && gameM.GreenWidePrism == 1 || isBlue && gameM.BlueUpPrism == 1 && gameM.BlueWidePrism == 1)
                {
                    num = num / 4;
                    num = Mathf.CeilToInt(num);
                    BulletObject = Instantiate(bullet, Spawner_01.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, new Vector2(Spawner_01.transform.position.x, Spawner_01.transform.position.y + 1f), Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, Spawner_03.transform.position, Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, new Vector2(Spawner_03.transform.position.x, Spawner_03.transform.position.y + 1f), Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                }
                else if (isRed && gameM.RedUpPrism == 1 || isGreen && gameM.GreenUpPrism == 1 || isBlue && gameM.BlueUpPrism == 1)
                {
                    num = num / 2;
                    num = Mathf.CeilToInt(num);
                    BulletObject = Instantiate(bullet, Spawner_02.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, new Vector2(Spawner_02.transform.position.x, Spawner_02.transform.position.y + 1f), Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                }
                else if (isRed && gameM.RedWidePrism == 1 || isGreen && gameM.GreenWidePrism == 1 || isBlue && gameM.BlueWidePrism == 1)
                {
                    num = num / 2;
                    num = Mathf.CeilToInt(num);
                    BulletObject = Instantiate(bullet, Spawner_01.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, Spawner_03.transform.position, Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;

                }
                else
                {
                    BulletObject = Instantiate(bullet, Spawner_02.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                }
                
                Destroy(this.gameObject);�@//�J�[�h������
            }
            else if (Lane_03)�@//03���[���ō��L�[�𗣂����Ƃ�
            {
                if (gameM.RedCountSensor || gameM.GreenCountSensor || gameM.BlueCountSensor)
                {
                    if (isRed) gameM.RedCount++;
                    if (isGreen) gameM.GreenCount++;
                    if (isBlue) gameM.BlueCount++;

                    if (gameM.RedCount == 5)
                    {
                        num *= 2;
                        gameM.RedCount = 0;
                    }
                    if (gameM.GreenCount == 5)
                    {
                        num *= 2;
                        gameM.GreenCount = 0;
                    }
                    if (gameM.BlueCount == 5)
                    {
                        num *= 2;
                        gameM.BlueCount = 0;
                    }
                }
                if (isRed && gameM.RedUpPrism == 1 && gameM.RedWidePrism == 1 || isGreen && gameM.GreenUpPrism == 1 && gameM.GreenWidePrism == 1 || isBlue && gameM.BlueUpPrism == 1 && gameM.BlueWidePrism == 1)
                {
                    num = num / 4;
                    num = Mathf.CeilToInt(num);
                    BulletObject = Instantiate(bullet, Spawner_02.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, new Vector2(Spawner_02.transform.position.x, Spawner_02.transform.position.y + 1f), Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, Spawner_03.transform.position, Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, new Vector2(Spawner_03.transform.position.x, Spawner_03.transform.position.y + 1f), Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                }
                else if (isRed && gameM.RedUpPrism == 1 || isGreen && gameM.GreenUpPrism == 1 || isBlue && gameM.BlueUpPrism == 1)
                {
                    num = num / 2;
                    num = Mathf.CeilToInt(num);
                    BulletObject = Instantiate(bullet, Spawner_03.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, new Vector2(Spawner_03.transform.position.x, Spawner_03.transform.position.y + 1f), Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                } 
                else if (isRed && gameM.RedWidePrism == 1 || isGreen && gameM.GreenWidePrism == 1 || isBlue && gameM.BlueWidePrism == 1)
                {
                    num = num / 2;
                    num = Mathf.CeilToInt(num);
                    BulletObject = Instantiate(bullet, Spawner_02.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                    BulletObject = Instantiate(bullet, Spawner_03.transform.position, Quaternion.identity);
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;

                }
                else
                {
                    BulletObject = Instantiate(bullet, Spawner_03.transform.position, Quaternion.identity); //�e���o��
                    BulletObject.GetComponent<Bullet>().numBullet = num;
                    if (Bubble) BulletObject.GetComponent<Bullet>().Bubble = true;
                }
                Destroy(this.gameObject);�@//�J�[�h������
            }
        }
    }

    private void IsRed()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); //�ԕ\��
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
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1); //�}�[���^�\��
    }
    private void IsCyan() {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1, 1);�@//��F�\��
    }

    private void IsWhite() {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);�@//���\��
    }

    private void ThisColor()
    {
        if (isRed && !isGreen && !isBlue) //�J�[�h�̐F�̏�񂪐Ԃ����������ꍇ
        {
            IsRed();�@//�ԕ\��
        }else if (!isRed && isGreen && !isBlue)�@//�J�[�h�̐F�̏�񂪗΂����������ꍇ
        {
            IsGreen();�@//�Ε\��
        }
        else if (!isRed && !isGreen && isBlue)�@//�J�[�h�̐F�̏�񂪐����������ꍇ
        {
            IsBlue();�@//�\��
        }else if(isRed && isGreen && !isBlue)�@//�J�[�h�̐F�̏�񂪐ԂƗ΂������ꍇ
        {
            IsYellow();�@//���F�\��
        }else if (isRed && !isGreen && isBlue)�@//�J�[�h�̐F�̏�񂪐ԂƐ������ꍇ
        {
            IsMagenta();�@//�}�[���^�\��
        }else if (!isRed && isGreen && isBlue)�@//�J�[�h�̐F�̏�񂪗΂Ɛ������ꍇ
        {
            IsCyan();�@//��F�\��
        }else if(isRed && isGreen && isBlue)�@//�J�[�h�̐F�̏�񂪐ԁA�΁A�������ꍇ
        {
            IsWhite();�@//���\��
        }
        else�@//�J�[�h�̐F�̏�񂪉����Ȃ������ꍇ
        {
            ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);�@//���\��
        }
    }
}
