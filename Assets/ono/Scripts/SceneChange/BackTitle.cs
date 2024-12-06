using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackTitle : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickButton);
    }

    private void Update()
    {
        
    }

    void ClickButton()
    {
        SceneManager.LoadScene("_TitleScene");
    }
}
