using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    Button button;
    [SerializeField] GameObject _Tutorial;
    private bool OnPage;
    void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if(!OnPage)
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
        _Tutorial.SetActive(true);
        OnPage = true;
        
    }
    void ExitButton()
    {
        _Tutorial.SetActive(false);
        OnPage= false;
    }
}
