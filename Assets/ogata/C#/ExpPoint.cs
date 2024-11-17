using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPoint : MonoBehaviour
{

    GameManager gameM;
    EXPbar ExpPos;

    private float forcePow;

    Rigidbody2D rb;
    private float veloX;

    [SerializeField]
    Vector2 force;

    [SerializeField]
    Vector2 forceDeb;

    float veloy;
    float velox;
    float forcex = 1.5f;
    float forcey = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EXPbar>())
        {
            ExpPos.nowExp++;
            if (gameM.LevelUpper)
            {
                ExpPos.nowExp++;
            }
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameM = FindObjectOfType<GameManager>();
        transform.parent = GameObject.Find ("GameField").transform;
        ExpPos = FindObjectOfType<EXPbar>();   
        rb = GetComponent<Rigidbody2D>();
        veloX = Random.Range(-5, 5);
        rb.velocity = new Vector2(veloX,5);
        veloy = 10;
        velox = 10;
        force = new Vector2(forcex, forcey);
    }

    // Update is called once per frame
    void Update()
    {
        force = new Vector2(forcex, forcey);
        if(transform.position.x < ExpPos.transform.position.x + 1 && transform.position.x > ExpPos.transform.position.x - 1)
        {
            Debug.Log("���E");
            velox -= 10 * Time.deltaTime;
            if(velox < 0)
            {
                velox = 0;
            }
        }
        if (transform.position.y < ExpPos.transform.position.y + 1 && transform.position.y > ExpPos.transform.position.y - 1)
        {
            Debug.Log("�㉺");
            veloy -= 3 * Time.deltaTime;
            if (veloy < 0)
            {
                veloy = 0;
            }
        }

        
        if (transform.position.y < ExpPos.transform.position.y)
        {
            if (transform.position.x < ExpPos.transform.position.x)
            {
                force = new Vector2(forcex, forcey);
            }
            if (transform.position.x > ExpPos.transform.position.x)
            {
                force = new Vector2(-forcex, forcey);
            }
        }
        if (transform.position.y > ExpPos.transform.position.y)
        {
            if (transform.position.x < ExpPos.transform.position.x)
            {
                force = new Vector2(forcex, -forcey);
            }
            if (transform.position.x > ExpPos.transform.position.x)
            {
                force = new Vector2(-forcex, -forcey);
            }
        }
        rb.AddForce(force);
        if(rb.velocity.y > veloy)
        {
            rb.velocity = new Vector2(rb.velocity.x, veloy);
        }
        if (rb.velocity.y < -veloy)
        {
            rb.velocity = new Vector2(rb.velocity.x, -veloy);
        }
        if (rb.velocity.x > velox)
        {
            rb.velocity = new Vector2(velox, rb.velocity.y);
        }
        if (rb.velocity.x < -velox)
        {
            rb.velocity = new Vector2(-velox, rb.velocity.y);
        }
        forceDeb = new Vector2(-rb.velocity.x, rb.velocity.y);
    }
   
}
