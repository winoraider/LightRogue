using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    Button button;
    [SerializeField] GameObject _Ranking;
    private bool OnPage;
    void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (!OnPage)
        {
            button.onClick.AddListener(ClickButton);
        }
        else
        {
            button.onClick.AddListener(ExitButton);
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
