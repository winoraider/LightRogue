using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float force;
    private bool action = false;
    public bool Action
    {
        get { return action; }
        set { action = value; }
    }

    private Rigidbody2D rb;

    private GameManager gameM;
    private EXPbar expbar;

    [SerializeField] private GameObject EXPPoint;
    public GameObject expPoint
    {
        get { return EXPPoint; }
        set { EXPPoint = value; }
    }

    [SerializeField] EnemyNumController enemyNumController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        expbar = FindObjectOfType<EXPbar>();
        gameM = FindObjectOfType<GameManager>();
        
    }
    private void Update()
    {
        if (!action)
        {
            rb.velocity = new Vector2(0, force);
        }
        else
        {
            HitPlayer();
        }
        
        GetExp();
    }

    private void HitPlayer()
    {
        if (gameM.KnockBack)
        {
            rb.velocity = new Vector2(0, 20f);
            action = false;
            return;
        }
        if (gameM.SlowTimer)
        { 
            rb.velocity = new Vector2(0, force * 0.8f);
            action = false;
        }
    }

    void GetExp()
    {
        if(enemyNumController.NowPower <= 0)
        {
            Instantiate(EXPPoint, transform.position, Quaternion.identity);
        }
    }
}
