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

    [SerializeField] Button Sbutton;
    [SerializeField] Button Rbutton;
    [SerializeField] Button Tbutton;

    private void Update()
    {
        if (!OnPage)
        {
            button.onClick.AddListener(ClickButton);
            Sbutton.enabled = true;
            Rbutton.enabled = true;
            Tbutton.enabled = true;
        }
        else
        {
            button2.onClick.AddListener(ExitButton);
            Sbutton.enabled = false;
            Rbutton.enabled = false;
            Tbutton.enabled = false;
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
