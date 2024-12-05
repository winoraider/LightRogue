using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EXPbar : MonoBehaviour
{

    Slider slider;
    GameManager gameM;

    [SerializeField]
    public float nowExp;

    [SerializeField]
    private GameObject LevelUpUi;

    private int LevelCount = 0;
    public int levelCount
    {
        get { return LevelCount; }
        set { LevelCount = value; }
    }
    void Start()
    {
        slider = GetComponent<Slider>();
        gameM = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        slider.value = nowExp / gameM.NeedEXP;
        if (Input.GetKeyDown(KeyCode.A))
        {
            nowExp++;
            if (gameM.LevelUpper)
            {
                nowExp++;
            }
        }
        if (slider.value >= 1)
        {
            LevelUpUi.SetActive(true);
            gameM.PlayerLevel++;
            nowExp = nowExp % gameM.NeedEXP;
            gameM.NeedEXP += gameM.AddNeedEXP;
            LevelCount++;
            Time.timeScale = 0;
        }
    }
}
