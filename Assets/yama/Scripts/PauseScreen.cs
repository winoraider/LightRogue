using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        pauseButton.SetActive(true);
        pauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        pauseButton.SetActive(true);
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

}
