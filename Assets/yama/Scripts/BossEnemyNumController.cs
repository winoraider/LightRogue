using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BossEnemyNumController : MonoBehaviour
{
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

    [SerializeField] private Timelimit timelimit;
    [SerializeField] private Timer timer;
    [SerializeField] Image Image1;

    public void EcardSetManager(ECardSpawn eCardSpawn)
    {
        this.eCard = eCardSpawn;
    }
    void Update()
    {
        BossToText = Mathf.CeilToInt(bossnowPower);
        if (bossnowPower <= 0f)
        {
            Destroy(gameObject);
            eCard.ECount += -1;
            eCard.BOSS = false;
            timelimit.Minutes = 1;
            Image1.fillAmount = 0f;
            //Debug.Log("ecount -1 ");
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
