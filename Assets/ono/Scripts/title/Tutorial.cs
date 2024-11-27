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
            button.enabled = true;
            Sbutton.enabled = true;
            Rbutton.enabled = true;
            Obutton.enabled = true;
        }
        else
        {
            Debug.Log("Tutorialオンページ" + OnPage);
            button2.onClick.AddListener(ExitButton);
            button.enabled = false;
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
