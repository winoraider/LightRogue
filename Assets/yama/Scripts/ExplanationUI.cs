using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExplanationUI : MonoBehaviour
{
    private string explanation;
    [SerializeField] private GameObject explanationScreen;
    [SerializeField] private Text explanationText;

    private void Start()
    {
        explanationScreen.SetActive(false);
    }

    private void OpenScreen()
    {

        explanationText.text = explanation;
        explanationScreen.SetActive(true);
    }

    public void CloseScreen()
    {
        explanationScreen.SetActive(false);
    }

    public void AllP()
    {
        explanation = "全てのカードのパワーが[+1]される";
        OpenScreen();
    }

    public void RP()
    {
        explanation = "レッドカードのパワーが[+3]される";
        OpenScreen();
    }

    public void GP()
    {
        explanation = "グリーンカードのパワーが[+3]される";
        OpenScreen();
    }

    public void BP()
    {
        explanation = "ブルーカードのパワーが[+3]される";
        OpenScreen();
    }

    public void RcomP()
    {
        explanation = "レッド同士を組み合わせることでパワーボーナス[+5]される";
        OpenScreen();
    }

    public void GcomP()
    {
        explanation = "グリーン同士を組み合わせることでパワーボーナス[+5]される";
        OpenScreen();
    }

    public void BcomP()
    {
        explanation = "ブルー同士を組み合わせることでパワーボーナス[+5]される";
        OpenScreen();
    }

    public void AddR()
    {
        explanation = "レッドカードを一枚追加する";
        OpenScreen();
    }

    public void AddG()
    {
        explanation = "グリーンカードを一枚追加する";
        OpenScreen();
    }

    public void AddB()
    {
        explanation = "ブルーカードを一枚追加する";
        OpenScreen();
    }

    public void McomP()
    {
        explanation = "マゼンタ同士を組み合わせることでパワーボーナス[+20]される";
        OpenScreen();
    }

    public void McomMag()
    {
        explanation = "マゼンタ生成時の倍率が[+0.5]される";
        OpenScreen();
    }

    public void CcomP()
    {
        explanation = "シアン同士を組み合わせることでパワーボーナス[+20]される";
        OpenScreen();
    }

    public void CcomMag()
    {
        explanation = "シアン生成時の倍率が[+0.5]される";
        OpenScreen();
    }

    public void YcomP()
    {
        explanation = "イエロー同士を組み合わせることでパワーボーナス[+20]される";
        OpenScreen();
    }

    public void YcomMag()
    {
        explanation = "イエロー生成時の倍率が[+0.5]される";
        OpenScreen();
    }

    public void WcomP()
    {
        explanation = "ホワイト同士を組み合わせることでパワーボーナス[+50]される";
        OpenScreen();
    }

    public void WcomMag()
    {
        explanation = "ホワイト生成時の倍率が[+0.5]される";
        OpenScreen();
    }

    public void Rwide()
    {
        explanation = "レッドカードを出すとき、値を1/2して横に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        OpenScreen();
    }

    public void Gwide()
    {
        explanation = "グリーンカードを出すとき、値を1/2して横に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        OpenScreen();
    }

    public void Bwide()
    {
        explanation = "ブルーカードを出すとき、値を1/2して横に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        OpenScreen();
    }

    public void Rup()
    {
        explanation = "レッドカードを出すとき、値を1/2して縦に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        OpenScreen();
    }

    public void Gup()
    {
        explanation = "グリーンカードを出すとき、値を1/2して縦に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        OpenScreen();
    }

    public void Bup()
    {
        explanation = "ブルーカードを出すとき、値を1/2して縦に2つの弾を出す\n同色のアッププリズムを入手していた場合、値を1/4にして、4つの弾を出す";
        OpenScreen();
    }

    public void Rcount()
    {
        explanation = "レッドカードを出すごとに値が1ずつカウントされるようになり、\n5に達した時点で出た弾の値が2倍になる\nその後カウントは0に戻り、レッドカードを出すたびに、1ずつカウントされる";
        OpenScreen();
    }

    public void Gcount()
    {
        explanation = "グリーンカードを出すごとに値が1ずつカウントされるようになり、\n5に達した時点で出た弾の値が2倍になる\nその後カウントは0に戻り、グリーンカードを出すたびに、1ずつカウントされる";
        OpenScreen();
    }

    public void Bcount()
    {
        explanation = "ブルーカードを出すごとに値が1ずつカウントされるようになり、\n5に達した時点で出た弾の値が2倍になる\nその後カウントは0に戻り、ブルーカードを出すたびに、1ずつカウントされる";
        OpenScreen();
    }

    public void Mcount()
    {
        explanation = "マゼンタカードを出すごとに値が1ずつカウントされるようになり、\n5に達した時点で出た弾の値が2倍になる\nその後カウントは0に戻り、マゼンタカードを出すたびに、1ずつカウントされる";
        OpenScreen();
    }

    public void Ccount()
    {
        explanation = "シアンカードを出すごとに値が1ずつカウントされるようになり、\n5に達した時点で出た弾の値が2倍になる\nその後カウントは0に戻り、シアンカードを出すたびに、1ずつカウントされる";
        OpenScreen();
    }

    public void Ycount()
    {
        explanation = "イエローカードを出すごとに値が1ずつカウントされるようになり、\n5に達した時点で出た弾の値が2倍になる\nその後カウントは0に戻り、イエローカードを出すたびに、1ずつカウントされる";
        OpenScreen();
    }

    public void Wcount()
    {
        explanation = "ホワイトカードを出すごとに値が1ずつカウントされるようになり、\n5に達した時点で出た弾の値が2倍になる\nその後カウントは0に戻り、ホワイトカードを出すたびに、1ずつカウントされる";
        OpenScreen();
    }

    public void Bubble()
    {
        explanation = "ランダムのカードにシャボンの効果がつく\nシャボンが付くと、10秒でライトは消滅するが\n1秒ごとに値が1.3倍されていく";
        OpenScreen();
    }

    public void LvUpper()
    {
        explanation = "獲得EXPに[+1]をする";
        OpenScreen();
    }

    public void SpeedUpper()
    {
        explanation = "ライトの速度が1.2倍になる";
        OpenScreen();
    }

    public void SlowTimer()
    {
        explanation = "5秒間、敵の速度が0.8倍になる";
        OpenScreen();
    }

    public void Flash()
    {
        explanation = "30秒毎に発動、敵全体に100ダメージを与える";
        OpenScreen();
    }

    public void WindowBomb()
    {
        explanation = "ライトを20発出す毎に、敵全体を上へ飛ばす";
        OpenScreen();
    }
}
