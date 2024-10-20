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

    public void OnClick1()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "弾の色を混ぜた際のパワー倍率が＋0.1される";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        ColorPow = true;
        CardPow = false;
        HpPow = false;
    }
    public void OnClick2()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "編成されている全てのカードのパワーが１プラスされる";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        ColorPow = false;
        CardPow = true;
        HpPow = false;
    }
    public void OnClick3()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "プレイヤーのHPが20プラスされる";
        if (OKButton != null)
        {
            OKButton.SetActive(true);
        }
        ColorPow = false;
        CardPow = false;
        HpPow = true;
    }
    public void OkClick()
    {
        if (ColorPow)
        {
            gameM.ColorLevel++;
            ColorPow = false;
        }
        if (CardPow)
        {
            gameM.CardLevel++;
            CardPow = false;
        }
        if (HpPow)
        {
            gameM.HpLevel++;
            HpPow=false;
        }
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "選んでください";
        Time.timeScale = 1;
        OKButton.SetActive(false);
        gameObject.SetActive(false);

    }
}
