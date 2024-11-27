using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    Rigidbody2D rb;

    GameManager gameM;
    EXPbar expbar;
    [SerializeField] private GameObject EXPPoint;

    [SerializeField] float force;
    [SerializeField]private float FastSpeed;
    [SerializeField] private float SlowSpeed;
    [SerializeField] private float AttackDamage;
    [SerializeField] private float KnockBack;

    [SerializeField] private float elapsedTime;
    [SerializeField] private float durationTime = 10f;

    ECardSpawn eCardSpawn;
    EnemyMove enemyMove;
    NumController numController;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        expbar = FindObjectOfType<EXPbar>();
        gameM = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        BossRelic();
        PlayerHitBoss();
    }

    void PlayerHitBoss()
    {
        if (gameM.KnockBack)
        {
            rb.velocity = new Vector2(0, 10f);
            enemyMove.Action = false;
            return;
        }
        if (gameM.SlowTimer)　//尾形いじった
        {
            rb.velocity = new Vector2(0, force * 0.8f);
            enemyMove.Action = false;
        }
    }

    private void BossRelic()
    {
        if (eCardSpawn.RelicNum() == 0)
        {
            //Debug.Log("ボスのスピードレリック");
            FastSpeed = 1.2f;
            rb.velocity = new Vector2(0, force * FastSpeed);
        }
        if (eCardSpawn.RelicNum() == 1)
        {
            //Debug.Log("ボスのスローレリック");
            SlowSpeed = 0.8f;
            rb.velocity = new Vector2(0, force * SlowSpeed);
        }
        if (eCardSpawn.RelicNum() == 2)
        {
            //Debug.Log("ボスの攻撃100レリック");
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= durationTime)
            {
                AttackDamage = 100;
                numController.biggerPower -= AttackDamage;
                elapsedTime = 0;
            }
        }
        if (eCardSpawn.RelicNum() == 3)
        {
            //Debug.Log("ボスのノックバックレリック");
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= durationTime)
            {
                KnockBack = -20f;
                rb.velocity = new Vector2(0, KnockBack);
                elapsedTime = 0;
            }
        }
    }
    void OnDestroy()
    {
        Instantiate(EXPPoint, transform.position, Quaternion.identity);　//尾形いじった 
        gameM.RelicOb.SetActive(true);
    }
}
