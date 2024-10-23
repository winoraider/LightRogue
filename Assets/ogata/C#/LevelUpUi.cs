using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUi : MonoBehaviour
{
    GameManager gameM;

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
   private  GameObject[] LevelUpButtans;

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

    
    // Start is called before the first frame update
    void Start()
    {
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
                    RandomNum = Random.Range(0, LevelUpButtans.Length);
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
    public void OkClick()
    {
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
