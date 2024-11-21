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
    void Start()
    {
        //button = GetComponent<Button>();
    }

    private void Update()
    {
        if(!OnPage)
        {
            button.onClick.AddListener(ClickButton);
            button.enabled = true;
        }
        else
        {
            button2.onClick.AddListener(ExitButton);
            button.enabled = false;
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
        OnPage= false;
    }
}
