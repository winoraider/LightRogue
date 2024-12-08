using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMove : MonoBehaviour
{
    Rigidbody2D rb;

    GameManager gameM;
    EXPbar expbar;
    [SerializeField] private GameObject EXPPoint;
    public GameObject expPoint
    {
        get { return EXPPoint; }
        set { EXPPoint = value; }
    }

    [SerializeField] float force;
    [SerializeField]private float FastSpeed;
    [SerializeField] private float SlowSpeed;
    [SerializeField] private float AttackDamage;
    [SerializeField] private float KnockBack;

    [SerializeField] private float elapsedTime;
    [SerializeField] private float durationTime = 1f;

    [SerializeField] private float timer;

    private float stopPositionY = 3f;

    [SerializeField]ECardSpawn eCard;
    [SerializeField] Bullet bullet;
    [SerializeField]BossEnemyNumController bossEnemyNumController;

    public void EcardSetManager(ECardSpawn eCardSpawn)
    {
        this.eCard = eCardSpawn;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        expbar = FindObjectOfType<EXPbar>();
        gameM = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (eCard.BOSS)
        {
            PlayerHitBoss();
            rb.velocity = new Vector2(0, force * Time.deltaTime);
        }
    }

    void PlayerHitBoss()
    {
        if (gameM.KnockBack)
        {
            rb.velocity = new Vector2(0, 10f);
            return;
        }
        if (gameM.SlowTimer)
        {
            rb.velocity = new Vector2(0, force * 0.8f);
        }
    }

#if false
void BossRelic()
    {
        if (eCard.bossRelicNum == 0)
        {
            FastSpeed = 1.2f;
            rb.velocity = new Vector2(0, force * FastSpeed);
        }
        if (eCard.bossRelicNum == 1)
        {
            SlowSpeed = 0.8f;
            rb.velocity = new Vector2(0, force * SlowSpeed);
        }
        if (eCard.bossRelicNum == 2)
        {
            rb.velocity = new Vector2(0, force);

            elapsedTime += Time.deltaTime;
            if(elapsedTime >= durationTime)
            {
                AttackDamage = 100;
                bullet.numBullet -= AttackDamage;
                elapsedTime = 0;
                //Debug.Log("aaa");
            }
        }
        if (eCard.bossRelicNum == 3)
        {
            rb.velocity = new Vector2(0, -1f);

            elapsedTime += Time.deltaTime;
            if (elapsedTime >= durationTime)
            {
                KnockBack = -0.1f;
                rb.velocity = new Vector2(0, force * KnockBack);
                elapsedTime = 0;
                //Debug.Log("bbb");
            }
        }
    }
#endif
}
