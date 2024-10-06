using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.PlayerSettings;

public class Card : MonoBehaviour
{
    [SerializeField]
    private int num; //カードの数字
    public int SendNum; //カードの情報を送る用

    private bool leftMouseKey = false; 

    [SerializeField]
    private GameObject BattleLane_01;
    [SerializeField]
    private GameObject BattleLane_02;
    [SerializeField]
    private GameObject BattleLane_03;

    [SerializeField] 
    private GameObject Spawner_01;
    [SerializeField]
    private GameObject Spawner_02;
    [SerializeField]
    private GameObject Spawner_03;
    
    [SerializeField]
    private TextMeshProUGUI numText;

    Vector2 MousePos;
    
    // Start is called before the first frame update
    void Start()
    {
        SendNum = num;　//送る用の数字の書き込み
    }

    // Update is called once per frame
    void Update()
    {
        numText.text = ""+num;

        if (leftMouseKey)
        {
            Vector2 tmpPos = Input.mousePosition;
            MousePos = Camera.main.ScreenToWorldPoint(tmpPos);
            transform.position = MousePos;

            
        }

        if (Input.GetMouseButtonUp(0)&& leftMouseKey)
        {
            leftMouseKey = false;
        }


    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            leftMouseKey = true;
        }
    }
}
