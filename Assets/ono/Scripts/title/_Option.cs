using UnityEngine;
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
            button.enabled = true;
            Sbutton.enabled = true;
            Rbutton.enabled = true;
            Tbutton.enabled = true;
        }
        else
        {
            button2.onClick.AddListener(ExitButton);
            button.enabled = false;
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
