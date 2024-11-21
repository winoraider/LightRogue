using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _Option : MonoBehaviour
{
    Button button;
    [SerializeField] GameObject Option;
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
        Option.SetActive(true);
        OnPage = true;

    }
    void ExitButton()
    {
        Option.SetActive(false);
        OnPage = false;
    }
}
