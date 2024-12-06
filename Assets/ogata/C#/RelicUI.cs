
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RelicUi : MonoBehaviour
{
    GameManager gameM;
    Card card;
    CardSpawner spawner;

    EventSystem eventSystem;

    [SerializeField]
    private GameObject CardUI;

    [SerializeField]
    private GameObject OKButton;

    [SerializeField]
    private GameObject Spawner_01;
    [SerializeField]
    private GameObject Spawner_02;
    [SerializeField]
    private GameObject Spawner_03;

    private GameObject SpawButtan_01;
    private GameObject SpawButtan_02;
    private GameObject SpawButtan_03;

    [SerializeField]
    private List<GameObject> RelicButtans;

    [SerializeField] 
    GameObject[] pauseRelicText = new GameObject[19];

    private int RelicRandom;
    private int ColorRandom;

    private bool[] usedcard = new bool[30];
    private bool[] spawcard = new bool[3];


    private bool ColorPow;
    private bool CardPow;
    private bool HpPow;

    [SerializeField]
    private int RelicBonus;

    [SerializeField]
    private bool Relicstart;

    private int Rednum;
    private int Greennum;
    private int Bluenum;

    [SerializeField]
    public GameObject Arrow;
    public GameObject CloneArrow;
    private GameObject tmp;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 18; i++)
        {
            pauseRelicText[i].SetActive(false);
        }
        spawner = FindObjectOfType<CardSpawner>();
        gameM = FindObjectOfType<GameManager>();
        eventSystem = FindObjectOfType<EventSystem>();
        OKButton.SetActive(false);
        gameObject.SetActive(false);
        Relicstart = true;
       RelicBonus = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventSystem.currentSelectedGameObject != null)
        {
            if (tmp != eventSystem.currentSelectedGameObject)
            {
                tmp = eventSystem.currentSelectedGameObject;
                Vector2 evPos = eventSystem.currentSelectedGameObject.transform.position;
                if (eventSystem.currentSelectedGameObject != GameObject.Find("GetButton"))
                {

                    if (CloneArrow != null)
                    {
                        Destroy(CloneArrow);
                    }
                    CloneArrow = Instantiate(Arrow, new Vector2(evPos.x, evPos.y + 180), Quaternion.identity);
                    CloneArrow.transform.parent = gameObject.transform;
                }
            }
        }
        if (Relicstart)
        {

            Time.timeScale = 0;
            for (int i = 0; i < 3; i++)
            {
                while (true)
                {
                    Relicstart = false;
                    RelicRandom = UnityEngine.Random.Range(0, RelicButtans.Count);
                    if (usedcard[RelicRandom] == true || RelicButtans[RelicRandom] == null)
                    {
                        //Debug.Log("���łɏo���l"+RelicRandom);
                        continue;
                    }
                    switch (i)
                    {
                        case 0:
                            SpawButtan_01 = Instantiate(RelicButtans[RelicRandom], Spawner_01.transform.position, Quaternion.identity);
                            SpawButtan_01.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;
                            //Debug.Log("1�o���l" + RelicRandom);
                            break;
                        case 1:
                            SpawButtan_02 = Instantiate(RelicButtans[RelicRandom], Spawner_02.transform.position, Quaternion.identity);
                            SpawButtan_02.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;

                            //Debug.Log("2�o���l" + RelicRandom);
                            break;
                        case 2:
                            SpawButtan_03 = Instantiate(RelicButtans[RelicRandom], Spawner_03.transform.position, Quaternion.identity);
                            SpawButtan_03.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;
                            //Debug.Log("3�o���l" + RelicRandom);
                            break;
                        default:

                            break;
                    }
                    break;
                }
            }
        }
        else
        {
            Debug.Log("�����Ă��܂�");
        }

    }

    public void RedWide(){

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "���b�h�J�[�h���o���Ƃ��A�l��1/2���ĉ���2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        RelicBonus = 0;
        OKButton.SetActive(true);
    }
    public void GreenWide()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�O���[���J�[�h���o���Ƃ��A�l��1/2���ĉ���2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        RelicBonus = 1;
        OKButton.SetActive(true);
    }
    public void BlueWide()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�u���[�J�[�h���o���Ƃ��A�l��1/2���ĉ���2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        RelicBonus = 2;
        OKButton.SetActive(true);
    }
    public void RedUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "���b�h�J�[�h���o���Ƃ��A�l��1/2���ďc��2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        RelicBonus = 3;
        OKButton.SetActive(true);
    }
    public void GreenUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�O���[���J�[�h���o���Ƃ��A�l��1/2���ďc��2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        RelicBonus = 4;
        OKButton.SetActive(true);
    }
    public void BlueUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�u���[�J�[�h���o���Ƃ��A�l��1/2���ďc��2�̒e���o��\n���F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        RelicBonus = 5;
        OKButton.SetActive(true);
    }

    public void RedCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "���b�h�J�[�h���o�����Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB�������_�ŏo���e�̒l��2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A���b�h�J�[�h���o�����тɁA1���J�E���g�����";
        RelicBonus = 6;
        OKButton.SetActive(true);
    }
    public void GreenCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�O���[���J�[�h���o�����Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB�������_�ŏo���e�̒l��2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�O���[���J�[�h���o�����тɁA1���J�E���g�����";
        RelicBonus = 7;
        OKButton.SetActive(true);
    }
    public void BlueCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�u���[�J�[�h���o�����Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB�������_�ŏo���e�̒l��2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�u���[�J�[�h���o�����тɁA1���J�E���g�����";
        RelicBonus = 8;
        OKButton.SetActive(true);
    }
    public void YellowCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�C�G���[�𐶐����邲�Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB����ƁA���̒e�̒l��������2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�C�G���[�𐶐����邽�тɁA1���J�E���g�����";
        RelicBonus = 9;
        OKButton.SetActive(true);
    }
    public void MagentaCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�}�[���^�𐶐����邲�Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB����ƁA���̒e�̒l��������2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�}�[���^�𐶐����邽�тɁA1���J�E���g�����";
        RelicBonus = 10;
        OKButton.SetActive(true);
    }
    public void CyanCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�V�A���𐶐����邲�Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB����ƁA���̒e�̒l��������2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�V�A���𐶐����邽�тɁA1���J�E���g�����";
        RelicBonus = 11;
        OKButton.SetActive(true);
    }
    public void WhiteCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�z���C�g�𐶐����邲�Ƃɒl��1���J�E���g�����悤�ɂȂ�A\n5�ɒB����ƁA���̒e�̒l��������2�{�ɂȂ�\n���̌�J�E���g��0�ɖ߂�A�z���C�g�𐶐����邽�тɁA1���J�E���g�����";
        RelicBonus = 12;
        OKButton.SetActive(true);
    }
    public void Bubble()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�����_���̃J�[�h�ɃV���{���̌��ʂ���\n�V���{�����t���ƁA10�b�Ń��C�g�͏��ł��邪\n1�b���Ƃɒl��1.3�{����Ă���";
        RelicBonus = 13;
        OKButton.SetActive(true);
    }
    public void LevelUpper()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�l��EXP��[+1]������";
        RelicBonus = 14;
        OKButton.SetActive(true);
    }
    public void SpeedUpper()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "���C�g�̑��x��1.2�{�ɂȂ�";
        RelicBonus = 15;
        OKButton.SetActive(true);
    }
    public void SlowTimer()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "5�b�ԁA�G�̑��x��0.8�{�ɂȂ�";
        RelicBonus = 16;
        OKButton.SetActive(true);
    }
    public void Flash()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "30�b���ɔ����A�G�S�̂�100�_���[�W��^����";
        RelicBonus = 17;
        OKButton.SetActive(true);
    }
    public void WindBoom()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "���C�g��20���o�����ɁA�G�S�̂���֔�΂�";
        RelicBonus = 18;
        OKButton.SetActive(true);
    }

    public void OkClick()
    {
        card = FindAnyObjectByType<Card>();
        switch (RelicBonus)
        {
            case 0:
                gameM.RedWidePrism++;
                Destroy(GameObject.Find("WideRed"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 1:
                gameM.GreenWidePrism++;
                Destroy(GameObject.Find("WideGreen"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 2:
                gameM.BlueWidePrism++;
                Destroy(GameObject.Find("WideBlue"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 3:
                gameM.RedUpPrism++;
                Destroy(GameObject.Find("UpRed"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 4:
                gameM.GreenUpPrism++;
                Destroy(GameObject.Find("UpGreen"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 5:
                gameM.BlueUpPrism++;
                Destroy(GameObject.Find("UpBlue"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 6:
                gameM.RedCount++;
                Destroy(GameObject.Find("CountRed"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 7:
                gameM.GreenCount++;
                Destroy(GameObject.Find("CountGreen"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 8:
                gameM.BlueCount++;
                Destroy(GameObject.Find("CountBlue"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 9:
                gameM.YellowCount++;
                Destroy(GameObject.Find("CountYellow"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 10:
                gameM.MagentaCount++;
                Destroy(GameObject.Find("CountMagenta"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
                case 11:
                gameM.CyanCount++;
                Destroy(GameObject.Find("CountCyan"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
                case 12:
                gameM.WhiteCount++;
                Destroy(GameObject.Find("CountWhite"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
                case 13:
                int tmp = Random.Range(0, spawner.cards.Count);
                spawner.cards[tmp].GetComponent<Card>().Bubble = true;
                Destroy(GameObject.Find("Bubble"));
                break;
            case 14:
                gameM.LevelUpper = true;
                Destroy(GameObject.Find("LevelUpper"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 15:
                gameM.SpeedUpper = true;
                Destroy(GameObject.Find("SpeedUpper"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
            case 16:
                gameM.SlowTimer = true;
                Destroy(GameObject.Find("SlowTimer"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
                case 17:
                gameM.flash = true;
                Destroy(GameObject.Find("Flash"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
                case 18:
                gameM.WindBoom = true;
                Destroy(GameObject.Find("WindBoom"));
                pauseRelicText[RelicBonus].SetActive(true);
                break;
        }

        for(int i = 0; i < usedcard.Length; i++)
        {
            usedcard[i] = false;
        }

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�I��ł�������";
        Time.timeScale = 1;
        Relicstart = true;
        Destroy(SpawButtan_01);
        Destroy(SpawButtan_02);
        Destroy(SpawButtan_03);
        Destroy(CloneArrow);
        OKButton.SetActive(false);
        gameObject.SetActive(false);
    }
}
