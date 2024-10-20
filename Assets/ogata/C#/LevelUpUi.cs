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

    private bool ColorPow;
    private bool CardPow;
    private bool HpPow;

    private int LevelBonus;

    
    // Start is called before the first frame update
    void Start()
    {
        gameM = FindObjectOfType<GameManager>();
        OKButton.SetActive(false);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }


        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "選んでください";
        Time.timeScale = 1;
        OKButton.SetActive(false);
        gameObject.SetActive(false);

    }
}
