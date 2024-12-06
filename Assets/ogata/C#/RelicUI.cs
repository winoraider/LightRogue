
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
                        //Debug.Log("すでに出た値"+RelicRandom);
                        continue;
                    }
                    switch (i)
                    {
                        case 0:
                            SpawButtan_01 = Instantiate(RelicButtans[RelicRandom], Spawner_01.transform.position, Quaternion.identity);
                            SpawButtan_01.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;
                            //Debug.Log("1出た値" + RelicRandom);
                            break;
                        case 1:
                            SpawButtan_02 = Instantiate(RelicButtans[RelicRandom], Spawner_02.transform.position, Quaternion.identity);
                            SpawButtan_02.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;

                            //Debug.Log("2出た値" + RelicRandom);
                            break;
                        case 2:
                            SpawButtan_03 = Instantiate(RelicButtans[RelicRandom], Spawner_03.transform.position, Quaternion.identity);
                            SpawButtan_03.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;
                            //Debug.Log("3出た値" + RelicRandom);
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

    public void RedWide(){

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "レッドカードを出すとき、値を1/2して横に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        RelicBonus = 0;
        OKButton.SetActive(true);
    }
    public void GreenWide()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "グリーンカードを出すとき、値を1/2して横に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        RelicBonus = 1;
        OKButton.SetActive(true);
    }
    public void BlueWide()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ブルーカードを出すとき、値を1/2して横に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        RelicBonus = 2;
        OKButton.SetActive(true);
    }
    public void RedUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "レッドカードを出すとき、値を1/2して縦に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        RelicBonus = 3;
        OKButton.SetActive(true);
    }
    public void GreenUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "グリーンカードを出すとき、値を1/2して縦に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        RelicBonus = 4;
        OKButton.SetActive(true);
    }
    public void BlueUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ブルーカードを出すとき、値を1/2して縦に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        RelicBonus = 5;
        OKButton.SetActive(true);
    }

    public void RedCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "レッドカードを出すごとに値が1ずつカウントされるようになり、\n5に達した時点で出た弾の値が2倍になる\nその後カウントは0に戻り、レッドカードを出すたびに、1ずつカウントされる";
        RelicBonus = 6;
        OKButton.SetActive(true);
    }
    public void GreenCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "グリーンカードを出すごとに値が1ずつカウントされるようになり、\n5に達した時点で出た弾の値が2倍になる\nその後カウントは0に戻り、グリーンカードを出すたびに、1ずつカウントされる";
        RelicBonus = 7;
        OKButton.SetActive(true);
    }
    public void BlueCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ブルーカードを出すごとに値が1ずつカウントされるようになり、\n5に達した時点で出た弾の値が2倍になる\nその後カウントは0に戻り、ブルーカードを出すたびに、1ずつカウントされる";
        RelicBonus = 8;
        OKButton.SetActive(true);
    }
    public void YellowCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "イエローを生成するごとに値が1ずつカウントされるようになり、\n5に達すると、その弾の値がいつもの2倍になる\nその後カウントは0に戻り、イエローを生成するたびに、1ずつカウントされる";
        RelicBonus = 9;
        OKButton.SetActive(true);
    }
    public void MagentaCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "マゼンタを生成するごとに値が1ずつカウントされるようになり、\n5に達すると、その弾の値がいつもの2倍になる\nその後カウントは0に戻り、マゼンタを生成するたびに、1ずつカウントされる";
        RelicBonus = 10;
        OKButton.SetActive(true);
    }
    public void CyanCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "シアンを生成するごとに値が1ずつカウントされるようになり、\n5に達すると、その弾の値がいつもの2倍になる\nその後カウントは0に戻り、シアンを生成するたびに、1ずつカウントされる";
        RelicBonus = 11;
        OKButton.SetActive(true);
    }
    public void WhiteCount()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ホワイトを生成するごとに値が1ずつカウントされるようになり、\n5に達すると、その弾の値がいつもの2倍になる\nその後カウントは0に戻り、ホワイトを生成するたびに、1ずつカウントされる";
        RelicBonus = 12;
        OKButton.SetActive(true);
    }
    public void Bubble()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ランダムのカードにシャボンの効果がつく\nシャボンが付くと、10秒でライトは消滅するが\n1秒ごとに値が1.3倍されていく";
        RelicBonus = 13;
        OKButton.SetActive(true);
    }
    public void LevelUpper()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "獲得EXPに[+1]をする";
        RelicBonus = 14;
        OKButton.SetActive(true);
    }
    public void SpeedUpper()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ライトの速度が1.2倍になる";
        RelicBonus = 15;
        OKButton.SetActive(true);
    }
    public void SlowTimer()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "5秒間、敵の速度が0.8倍になる";
        RelicBonus = 16;
        OKButton.SetActive(true);
    }
    public void Flash()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "30秒毎に発動、敵全体に100ダメージを与える";
        RelicBonus = 17;
        OKButton.SetActive(true);
    }
    public void WindBoom()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ライトを20発出す毎に、敵全体を上へ飛ばす";
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
        cardtext.text = "選んでください";
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
