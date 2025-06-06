using UnityEngine;

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
}
