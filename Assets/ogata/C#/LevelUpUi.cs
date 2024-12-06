using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelUpUi : MonoBehaviour
{
    GameManager gameM;
    Card card;
    CardSpawner spawner;
    EventSystem eventSystem;
    PauseLvUI pauseUI;

    [SerializeField]
    private GameObject CardUI;

    [SerializeField]
    private GameObject[] PauseLvUpUI = new GameObject[18];

    [SerializeField]
    private GameObject[] GetNumUI = new GameObject[18];

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

    [SerializeField]
    public GameObject Arrow;
    public GameObject CloneArrow;
    private GameObject tmp;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 18;  i++)
        {
            PauseLvUpUI[i].SetActive(false);
            GetNumUI[i].SetActive(true);
        }
        spawner = FindObjectOfType<CardSpawner>();
        gameM = FindObjectOfType<GameManager>();
        eventSystem = FindObjectOfType<EventSystem>();
        pauseUI = FindAnyObjectByType<PauseLvUI>();
        OKButton.SetActive(false);
        gameObject.SetActive(false);
        LevelUpstart = true;
        LevelBonus = -1;
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
            {

            }
            if (LevelUpstart)
            {
                for (int i = 0; i < spawcard.Length; i++)
                {
                    while (true)
                    {
                        RandomNum = UnityEngine.Random.Range(0, LevelUpButtans.Count);
                        if (usedcard[RandomNum] == true)
                        {
                            continue;
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
                //Debug.Log("動いています");
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
        Text getnum = GetNumUI[LevelBonus].GetComponent<Text>();
        switch (LevelBonus)
        {
            case 0:
                gameM.RedPowLevel++;
                pauseUI.rp++;
                getnum.text = "+" + pauseUI.rp;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 1:
                gameM.GreenPowLevel++;
                pauseUI.gp++;
                getnum.text = "+" + pauseUI.gp;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 2:
                gameM.BluePowLevel++;
                pauseUI.bp++;
                getnum.text = "+" + pauseUI.bp;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 3:
                gameM.ALLPowLevel++;
                pauseUI.allP++;
                getnum.text = "+" + pauseUI.allP;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 4:
                gameM.RedAddPowLevel++;
                pauseUI.rcom++;
                getnum.text = "+" + pauseUI.rcom;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 5:
                gameM.GreenAddPowLevel++;
                pauseUI.gcom++;
                getnum.text = "+" + pauseUI.gcom;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 6:
                gameM.BlueAddPowLevel++;
                pauseUI.bcom++;
                getnum.text = "+" + pauseUI.bcom;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 7:
                gameM.YellowAddPowLevel++;
                pauseUI.ycom++;
                getnum.text = "+" + pauseUI.ycom;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 8:
                gameM.MagentaAddPowLevel++;
                pauseUI.mcom++;
                getnum.text = "+" + pauseUI.mcom;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 9:
                gameM.CyanAddPowLevel++;
                pauseUI.ccom++;
                getnum.text = "+" + pauseUI.ccom;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 10:
                gameM.YellowMagPowLevel++;
                pauseUI.ycomMag++;
                getnum.text = "+" + pauseUI.ycomMag;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 11:
                gameM.MagentaMagPowLevel++;
                pauseUI.mcomMag++;
                getnum.text = "+" + pauseUI.mcomMag;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 12:
                gameM.CyanMagPowLevel++;
                pauseUI.ccomMag++;
                getnum.text = "+" + pauseUI.ccomMag;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 13:
                gameM.WhiteMagPowLevel++;
                pauseUI.wcom++;
                getnum.text = "+" + pauseUI.wcom;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 14:
                gameM.WhiteAddPowLevel++;
                pauseUI.wcomMag++;
                getnum.text = "+" + pauseUI.wcomMag;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 15:
                Rednum++;
                pauseUI.addRC++;
                getnum.text = "+" + pauseUI.addRC;
                if (Rednum > 3)
                {
                    Rednum = 1;
                }
                GameObject gameObject1 = Instantiate(AddCard);
                spawner.cards.Add(gameObject1);
                spawner.cards[spawner.cards.Count - 1].gameObject.GetComponent<Card>().isRed = true;
                spawner.cards[spawner.cards.Count - 1].gameObject.GetComponent<Card>().num = Rednum;
                gameObject1.gameObject.transform.parent = AddDeck.transform;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 16:
                Greennum++;
                pauseUI.addGC++;
                getnum.text = "+" + pauseUI.addGC;
                if (Greennum > 3)
                {
                    Greennum = 1;
                }
                gameObject1 = Instantiate(AddCard);
                spawner.cards.Add(gameObject1);
                spawner.cards[spawner.cards.Count-1].gameObject.GetComponent<Card>().isGreen = true;
                spawner.cards[spawner.cards.Count - 1].gameObject.GetComponent<Card>().num = Greennum;
                gameObject1.gameObject.transform.parent = AddDeck.transform;
                PauseLvUpUI[LevelBonus].SetActive(true);
                break;
            case 17:
                Bluenum++;
                pauseUI.addBC++;
                getnum.text = "+" + pauseUI.addBC;
                if (Bluenum > 3)
                {
                    Bluenum = 1;
                }
                gameObject1 = Instantiate(AddCard);
                spawner.cards.Add(gameObject1);
                spawner.cards[spawner.cards.Count-1].gameObject.GetComponent<Card>().isBlue = true;
                spawner.cards[spawner.cards.Count - 1].gameObject.GetComponent<Card>().num = Bluenum;
                gameObject1.gameObject.transform.parent = AddDeck.transform;
                PauseLvUpUI[LevelBonus].SetActive(true);
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
        Destroy(CloneArrow);
        OKButton.SetActive(false);
        gameObject.SetActive(false);
    }
}
