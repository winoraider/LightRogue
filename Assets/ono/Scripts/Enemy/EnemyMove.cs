using UnityEngine;

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
    private bool expInstatited = false;

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
}
