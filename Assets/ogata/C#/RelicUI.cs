
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicUi : MonoBehaviour
{
    GameManager gameM;
    Card card;
    CardSpawner spawner;

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

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<CardSpawner>();
        gameM = FindObjectOfType<GameManager>();
        OKButton.SetActive(false);
        gameObject.SetActive(false);
        Relicstart = true;
       RelicBonus = -1;
    }

    // Update is called once per frame
    void Update()
    {
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
                        Debug.Log("���łɏo���l"+RelicRandom);
                        continue;
                    }
                    switch (i)
                    {
                        case 0:
                            SpawButtan_01 = Instantiate(RelicButtans[RelicRandom], Spawner_01.transform.position, Quaternion.identity);
                            SpawButtan_01.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;
                            Debug.Log("1�o���l" + RelicRandom);
                            break;
                        case 1:
                            SpawButtan_02 = Instantiate(RelicButtans[RelicRandom], Spawner_02.transform.position, Quaternion.identity);
                            SpawButtan_02.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;

                            Debug.Log("2�o���l" + RelicRandom);
                            break;
                        case 2:
                            SpawButtan_03 = Instantiate(RelicButtans[RelicRandom], Spawner_03.transform.position, Quaternion.identity);
                            SpawButtan_03.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;
                            Debug.Log("3�o���l" + RelicRandom);
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
        cardtext.text = "���b�h�J�[�h���o���Ƃ��A�l��1/2���ĉ���2�̒e���o��\n�����F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        RelicBonus = 0;
        OKButton.SetActive(true);
    }
    public void GreenWide()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�O���[���J�[�h���o���Ƃ��A�l��1/2���ĉ���2�̒e���o��\n�����F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        RelicBonus = 1;
        OKButton.SetActive(true);
    }
    public void BlueWide()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�u���[�J�[�h���o���Ƃ��A�l��1/2���ĉ���2�̒e���o��\n�����F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        RelicBonus = 2;
        OKButton.SetActive(true);
    }
    public void RedUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "���b�h�J�[�h���o���Ƃ��A�l��1/2���ďc��2�̒e���o��\n�����F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        RelicBonus = 3;
        OKButton.SetActive(true);
    }
    public void GreenUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�O���[���J�[�h���o���Ƃ��A�l��1/2���ďc��2�̒e���o��\n�����F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
        RelicBonus = 4;
        OKButton.SetActive(true);
    }
    public void BlueUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�u���[�J�[�h���o���Ƃ��A�l��1/2���ďc��2�̒e���o��\n�����F�̃A�b�v�v���Y������肵�Ă����ꍇ�A�l��1/4�ɂ��āA4�̒e���o��";
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
        cardtext.text = "�����_���̃J�[�h�ɃV���{���̌��ʂ���\n�V���{�����t���ƁA1�b���Ƃɒl��1.3�{����Ă���";
        RelicBonus = 13;
        OKButton.SetActive(true);
    }
    public void LevelUpper()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�G����Ⴆ��o���l��2�{�ɂȂ�";
        RelicBonus = 14;
        OKButton.SetActive(true);
    }
    public void SpeedUpper()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "�e�̑��x��1.3�{�ɂȂ�";
        RelicBonus = 15;
        OKButton.SetActive(true);
    }

    public void OkClick()
    {
        card = FindAnyObjectByType<Card>();
        switch (RelicBonus)
        {
            case 0:
                gameM.RedWidePrism++;
                break;
            case 1:
                gameM.GreenWidePrism++;
                break;
            case 2:
                gameM.BlueWidePrism++;
                break;
            case 3:
                gameM.RedUpPrism++;
                break;
            case 4:
                gameM.GreenUpPrism++;
                break;
            case 5:
                gameM.BlueUpPrism++;
                break;
            case 6:
                gameM.RedCount++;
                break;
            case 7:
                gameM.GreenCount++;
                break;
            case 8:
                gameM.BlueCount++;
                break;
            case 9:
                gameM.YellowCount++;
                break;
            case 10:
                gameM.MagentaCount++;
                break;
                case 11:
                gameM.CyanCount++;
                break;
                case 12:
                gameM.WhiteCount++;
                break;
                case 13:
                int tmp = Random.Range(0, spawner.cards.Count);
                spawner.cards[tmp].GetComponent<Card>().Bubble = true;
                break;
            case 14:
                gameM.LevelUpper = true;
                break;
            case 15:
                gameM.SpeedUpper = true;
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
        OKButton.SetActive(false);
        gameObject.SetActive(false);
    }
}
