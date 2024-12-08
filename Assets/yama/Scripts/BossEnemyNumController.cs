using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BossEnemyNumController : MonoBehaviour
{

    [SerializeField]GameManager gameM;
    EXPbar expbar;
    [SerializeField] private GameObject EXPPoint;
    public GameObject expPoint
    {
        get { return EXPPoint; }
        set { EXPPoint = value; }
    }

    float counter;
    bool hit = false;
    int BossToText;

    private float bossnowPower;
    public float BossNowPower
    {
        get { return this.bossnowPower; }
        set { this.bossnowPower = value; }
    }
    public float comparePower;
    private string objName;

    [SerializeField] private ECardSpawn eCard;

    [SerializeField] TextMeshProUGUI BossText;

    //[SerializeField] private Timelimit timelimit;
    //[SerializeField] private Timer timer;
    //[SerializeField] Image Image1;

    public void EcardSetManager(ECardSpawn eCardSpawn)
    {
        this.eCard = eCardSpawn;
    }

    private void Start()
    {
        gameM = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        BossToText = Mathf.CeilToInt(bossnowPower);
        if (bossnowPower <= 0f)
        {
            Instantiate(EXPPoint, transform.position, Quaternion.identity);
            gameM.RelicOb.SetActive(true);
            eCard.deadBoss = true;
            eCard.BOSS = false;
            Destroy(gameObject);
        }
        BossText.text = "" + BossToText;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        comparePower = bossnowPower;
        objName = collision.gameObject.name;

        if(collision.gameObject.GetComponent<NumController>()) { 
        hit = true;
        }
        //GameObject obj = GameObject.Find(objName);
        //playerCard = obj.GetComponent<PlayerCard>();
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hit = false;
    }
}
