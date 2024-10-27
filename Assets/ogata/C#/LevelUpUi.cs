using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUi : MonoBehaviour
{
    GameManager gameM;
    Card card;
    CardSpawner spawner;

    [SerializeField]
    private GameObject CardUI;

    [SerializeField]
    private GameObject OKButton;

    [SerializeField] private GameObject AddCard;

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
    private List<GameObject> LevelUpButtans;

    [SerializeField]
    private GameObject AddDeck;

    private int RandomNum;

    private bool[] usedcard = new bool[30];
    private bool[] spawcard = new bool[3];


    private bool ColorPow;
    private bool CardPow;
    private bool HpPow;

    [SerializeField]
    private int LevelBonus;

    [SerializeField]
    private bool LevelUpstart;

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
        LevelUpstart = true;
        LevelBonus = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelUpstart)
        {
            for (int i = 0; i < spawcard.Length; i++)
            {
                while (true)
                {
                    RandomNum = UnityEngine.Random.Range(0, LevelUpButtans.Count);
                    if (usedcard[RandomNum] == true)
                    {
                        return;
                    }
                    switch (i)
                    {
                        case 0:
                            SpawButtan_01 = Instantiate(LevelUpButtans[RandomNum], Spawner_01.transform.position, Quaternion.identity);
                            SpawButtan_01.transform.parent = gameObject.transform;
                            usedcard[RandomNum] = true;
                            break;
                        case 1:
                            SpawButtan_02 = Instantiate(LevelUpButtans[RandomNum], Spawner_02.transform.position, Quaternion.identity);
                            SpawButtan_02.transform.parent = gameObject.transform;
                            usedcard[RandomNum] = true;
                            break;
                        case 2:
                            SpawButtan_03 = Instantiate(LevelUpButtans[RandomNum], Spawner_03.transform.position, Quaternion.identity);
                            SpawButtan_03.transform.parent = gameObject.transform;
                            usedcard[RandomNum] = true;
                            LevelUpstart = false;
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
            Debug.Log("動いています");
        }

    }

    public void RedEne()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "レッドカードのパワーが[+3]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 0;
    }
    public void GreenEne()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "グリーンカードのパワーが[+3]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 1;
    }
    public void BlueEne()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ブルーカードのパワーが[+3]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 2;
    }
    public void ALLEne()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "全てのカードのパワーが[+1]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 3;
    }
    public void RedAdd()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "レッド同士を組み合わせることでパワーボーナス[+5]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 4;
    }
    public void GreenAdd()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "グリーン同士を組み合わせることでパワーボーナス[+5]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 5;
    }
    public void BlueAdd()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ブルー同士を組み合わせることでパワーボーナス[+5]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 6;
    }
    public void YellowAdd()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "イエロー同士を組み合わせることでパワーボーナス[+20]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 7;
    }
    public void MagentaAdd()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "マゼンタ同士を組み合わせることでパワーボーナス[+20]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 8;
    }
    public void CyanAdd()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "シアン同士を組み合わせることでパワーボーナス[+20]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 9;
    }
    public void YellowMag()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "イエロー生成時の倍率が[+0.5]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 10;
    }
    public void MagentaMag()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "マゼンタ生成時の倍率が[+0.5]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 11;
    }
    public void CyanMag()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "シアン生成時の倍率が[+0.5]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 12;
    }
    public void WhiteMag()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ホワイト生成時の倍率が[+0.5]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 13;
    }
    public void WhiteAdd()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ホワイト同士を組み合わせることでパワーボーナス[+50]される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 14;
    }
    public void RedCardAdd()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "レッドカードを一枚追加する";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 15;
    }
    public void GreenCardAdd()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "グリーンカードを一枚追加する";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 16;
    }
    public void BlueCardAdd()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ブルーカードを一枚追加する";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        LevelBonus = 17;
    }
    public void OkClick()
    {
        card = FindAnyObjectByType<Card>();
        switch (LevelBonus)
        {
            case 0:
                gameM.RedPowLevel++;
                break;
            case 1:
                gameM.GreenPowLevel++;
                break;
            case 2:
                gameM.BluePowLevel++;
                break;
            case 3:
                gameM.ALLPowLevel++;
                break;
            case 4:
                gameM.RedAddPowLevel++;
                break;
            case 5:
                gameM.GreenAddPowLevel++;
                break;
            case 6:
                gameM.BlueAddPowLevel++;
                break;
            case 7:
                gameM.YellowAddPowLevel++;
                break;
            case 8:
                gameM.MagentaAddPowLevel++;
                break;
            case 9:
                gameM.CyanAddPowLevel++;
                break;
            case 10:
                gameM.YellowMagPowLevel++;
                break;
            case 11:
                gameM.MagentaMagPowLevel++;
                break;
            case 12:
                gameM.CyanMagPowLevel++;
                break;
                case 13:
                gameM.WhiteMagPowLevel++;
                break;
                case 14:
                gameM.WhiteAddPowLevel++;
                break;
            case 15:
                Rednum++;
                if(Rednum > 3)
                {
                    Rednum = 1;
                }
                GameObject gameObject1 = Instantiate(AddCard);
                spawner.cards.Add(gameObject1);
                spawner.cards[spawner.cards.Count - 1].gameObject.GetComponent<Card>().isRed = true;
                spawner.cards[spawner.cards.Count - 1].gameObject.GetComponent<Card>().num = Rednum;
                gameObject1.gameObject.transform.parent = AddDeck.transform;
                break;
            case 16:
                Greennum++;
                if (Greennum > 3)
                {
                    Greennum = 1;
                }
                gameObject1 = Instantiate(AddCard);
                spawner.cards.Add(gameObject1);
                spawner.cards[spawner.cards.Count-1].gameObject.GetComponent<Card>().isGreen = true;
                spawner.cards[spawner.cards.Count - 1].gameObject.GetComponent<Card>().num = Greennum;
                gameObject1.gameObject.transform.parent = AddDeck.transform;
                break;
            case 17:
                Bluenum++;
                if (Bluenum > 3)
                {
                    Bluenum = 1;
                }
                gameObject1 = Instantiate(AddCard);
                spawner.cards.Add(gameObject1);
                spawner.cards[spawner.cards.Count-1].gameObject.GetComponent<Card>().isBlue = true;
                spawner.cards[spawner.cards.Count - 1].gameObject.GetComponent<Card>().num = Bluenum;
                gameObject1.gameObject.transform.parent = AddDeck.transform;
                break;
        }

        for(int i = 0; i < usedcard.Length; i++)
        {
            usedcard[i] = false;
        }

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "選んでください";
        Time.timeScale = 1;
        LevelUpstart = true;
        Destroy(SpawButtan_01);
        Destroy(SpawButtan_02);
        Destroy(SpawButtan_03);
        OKButton.SetActive(false);
        gameObject.SetActive(false);
    }
}
