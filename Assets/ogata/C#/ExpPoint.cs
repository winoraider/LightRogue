using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPoint : MonoBehaviour
{
    [SerializeField] private Transform target;
    GameManager gameM;
    EXPbar ExpPos;
    Rigidbody2D rb;
    [SerializeField]
    private float step;

    [SerializeField]
    private float currentTime = 0;

    Vector3 startPos;
    Vector3 force;
    private float startforce;
    private float countDown = 0.8f;

    [SerializeField]
    private GameObject effe;


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
        target = ExpPos.transform;
        startPos = transform.position;

        startforce = Random.Range(-3, 3);
        rb.velocity = new Vector2(startforce,6);
        force = rb.velocity;
    }


    // Update is called once per frame
    void Update()
    {
        Instantiate(effe, transform.position, Quaternion.identity);
        if (countDown > 0.2f)
        {
            countDown -= Time.deltaTime;
            rb.velocity = force * countDown;
            startPos = transform.position;
        }
        else{
            Effe();
        }
    }
    private void Effe()
    {
        {
            currentTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, target.position, (currentTime*currentTime) / step);

        }
    }
        
}
