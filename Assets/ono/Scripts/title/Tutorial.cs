using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField]Button button;
    [SerializeField] Button button2;
    [SerializeField] GameObject _Tutorial;
    private bool OnPage;

    [SerializeField] Button Sbutton;
    [SerializeField] Button Rbutton;
    [SerializeField] Button Obutton;
    private void Update()
    {
        if(!OnPage)
        {
            button.onClick.AddListener(ClickButton);
            Sbutton.enabled = true;
            Rbutton.enabled = true;
            Obutton.enabled = true;
        }
        else
        {
            button2.onClick.AddListener(ExitButton);
            Sbutton.enabled = false;
            Rbutton.enabled = false;
            Obutton.enabled = false;
        }
    }
    void ClickButton()
    {
        _Tutorial.SetActive(true);
        OnPage = true;
        
    }
    void ExitButton()
    {
        _Tutorial.SetActive(false);
        OnPage = false;
    }
}
