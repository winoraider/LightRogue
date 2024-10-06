using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.PlayerSettings;

public class Card : MonoBehaviour
{
    GameManager gameM;

    [SerializeField]
    private float num; //カードの数字
    public int SendNum; //カードの情報を送る用

    private bool leftMouseKey = false;
    [SerializeField]
    private GameObject bullet;

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0) && leftMouseKey)
        {
            gameM.BulletNum = num;
            leftMouseKey = false;

            if (collision.gameObject.name == "BattleLane_01")
            {
                Instantiate(bullet, Spawner_01.transform.position, Quaternion.identity);
            }
            else if (collision.gameObject.name == "BattleLane_02")
            {
                Instantiate(bullet, Spawner_02.transform.position, Quaternion.identity);
            }
            else if (collision.gameObject.name == "BattleLane_03")
            {
                Instantiate(bullet, Spawner_03.transform.position, Quaternion.identity);
            }
        }

    }

    void Start()
    {
        gameM = GameObject.FindObjectOfType<GameManager>();
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
