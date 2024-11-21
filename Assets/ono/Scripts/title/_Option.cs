using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _Option : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Button button2;
    [SerializeField] GameObject Option;
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
        Option.SetActive(true);
        OnPage = true;

    }
    void ExitButton()
    {
        Option.SetActive(false);
        OnPage = false;
    }
}
