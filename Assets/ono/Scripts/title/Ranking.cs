using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    [SerializeField]Button button;
    [SerializeField] Button button2;
    [SerializeField] GameObject _Ranking;
    private bool OnPage;

    private void Update()
    {
        if (!OnPage)
        {
            button.onClick.AddListener(ClickButton);
        }
        else
        {
            button2.onClick.AddListener(ExitButton);
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
