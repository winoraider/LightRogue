using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundPlayerManager : MonoBehaviour
{
    [SerializeField] private AroundPlayer redAround;
    [SerializeField] private AroundPlayer greenAround;
    [SerializeField] private AroundPlayer blueAround;
    [SerializeField] private Bullet bullet;

    private bool isRed = false;
    private bool isGreen = false;
    private bool isBlue = false;

    GameManager gameManager;

    private void Update()
    {
        if (bullet.isRed)
        {
            RedActivate();
        }
        if (bullet.isGreen)
        {
            GreenActivate();
        }
        if (bullet.isBlue)
        {
            BlueActivate();
        }
        //if (Input.GetKeyDown(KeyCode.I)) RedActivate();
        //if (Input.GetKeyDown(KeyCode.O)) BlueActivate(); 
        //if (Input.GetKeyDown(KeyCode.P)) GreenActivate(); 
    }

    public void RedActivate()
    {
        if(isRed) return;
        redAround.Active();
        isRed = true;
        CheckCount();
    }
    public void GreenActivate()
    {
        if (isGreen) return;
        greenAround.Active();
        isGreen = true;
        CheckCount();
    }
    public void BlueActivate()
    {
        if (isBlue) return;
        blueAround.Active();    
        isBlue = true;
        CheckCount();
    }

    private void CheckCount()
    {
        int count = 0;
        List<AroundPlayer> aroundPlayers = new List<AroundPlayer>();
        if (isRed)
        {
            count++;
            aroundPlayers.Add(redAround);
        }
        if(isGreen)
        {
            count++;
            aroundPlayers.Add(greenAround);
        }
        if (isBlue)
        {
            count++;
            aroundPlayers.Add(blueAround);
        }
        for(int i = 0; i < aroundPlayers.Count; i++)
        {
            aroundPlayers[i].SetAngle(360f / count * i);
        }
    }
}
