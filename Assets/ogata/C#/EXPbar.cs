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
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        gameM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = nowExp / gameM.NeedEXP;
        if (Input.GetKeyDown(KeyCode.A))
        {
            nowExp += 1;
        }
        if (slider.value >= 1)
        {
            LevelUpUi.SetActive(true);
            gameM.PlayerLevel++;
            nowExp = nowExp % gameM.NeedEXP;
            gameM.NeedEXP += gameM.AddNeedEXP;
            Time.timeScale = 0;
        }
    }
}
