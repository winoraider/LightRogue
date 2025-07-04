using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    [SerializeField]Button button;
    [SerializeField] Button button2;
    [SerializeField] GameObject _Ranking;
    private bool OnPage;

    [SerializeField] Button Sbutton;
    [SerializeField] Button Tbutton;
    [SerializeField] Button Obutton;

    [SerializeField] RankingText rankingText;

    private void Update()
    {
        if (!OnPage)
        {
            button.onClick.AddListener(ClickButton);
            button.enabled = true;
            Sbutton.enabled = true;
            Tbutton.enabled = true;
            Obutton.enabled = true;
            rankingText.onText = true;
        }
        else
        {
            button2.onClick.AddListener(ExitButton);
            button.enabled = false;
            Sbutton.enabled = false;
            Tbutton.enabled = false;
            Obutton.enabled = false;
        }
    }
    void ClickButton()
    {
        _Ranking.SetActive(true);
        OnPage = true;

    }
    void ExitButton()
    {
        _Ranking.SetActive(false);
        OnPage = false;
    }
}
