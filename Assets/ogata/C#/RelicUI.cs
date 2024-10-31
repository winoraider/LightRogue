
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
                        Debug.Log("すでに出た値"+RelicRandom);
                        continue;
                    }
                    switch (i)
                    {
                        case 0:
                            SpawButtan_01 = Instantiate(RelicButtans[RelicRandom], Spawner_01.transform.position, Quaternion.identity);
                            SpawButtan_01.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;
                            Debug.Log("1出た値" + RelicRandom);
                            break;
                        case 1:
                            SpawButtan_02 = Instantiate(RelicButtans[RelicRandom], Spawner_02.transform.position, Quaternion.identity);
                            SpawButtan_02.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;

                            Debug.Log("2出た値" + RelicRandom);
                            break;
                        case 2:
                            SpawButtan_03 = Instantiate(RelicButtans[RelicRandom], Spawner_03.transform.position, Quaternion.identity);
                            SpawButtan_03.transform.parent = gameObject.transform;
                            usedcard[RelicRandom] = true;
                            Debug.Log("3出た値" + RelicRandom);
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
        cardtext.text = "レッドカードを出すとき、値を1/2して横に2つの弾を出す\n同じ色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        RelicBonus = 0;
        OKButton.SetActive(true);
    }
    public void GreenWide()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "グリーンカードを出すとき、値を1/2して横に2つの弾を出す\n同じ色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        RelicBonus = 1;
        OKButton.SetActive(true);
    }
    public void BlueWide()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ブルーカードを出すとき、値を1/2して横に2つの弾を出す\n同じ色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        RelicBonus = 2;
        OKButton.SetActive(true);
    }
    public void RedUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "レッドカードを出すとき、値を1/2して縦に2つの弾を出す\n同じ色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        RelicBonus = 3;
        OKButton.SetActive(true);
    }
    public void GreenUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "グリーンカードを出すとき、値を1/2して縦に2つの弾を出す\n同じ色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        RelicBonus = 4;
        OKButton.SetActive(true);
    }
    public void BlueUp()
    {

        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "ブルーカードを出すとき、値を1/2して縦に2つの弾を出す\n同じ色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
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
        cardtext.text = "ランダムのカードにシャボンの効果がつく\nシャボンが付くと、1秒ごとに値が1.3倍されていく";
        RelicBonus = 13;
        OKButton.SetActive(true);
    }
    public void LevelUpper()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "敵から貰える経験値が2倍になる";
        RelicBonus = 14;
        OKButton.SetActive(true);
    }
    public void SpeedUpper()
    {
        Text cardtext = CardUI.GetComponent<Text>();
        cardtext.text = "弾の速度が1.3倍になる";
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
        cardtext.text = "選んでください";
        Time.timeScale = 1;
        Relicstart = true;
        Destroy(SpawButtan_01);
        Destroy(SpawButtan_02);
        Destroy(SpawButtan_03);
        OKButton.SetActive(false);
        gameObject.SetActive(false);
    }
}
