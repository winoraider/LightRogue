using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gameM;

    [SerializeField]
    private float speed;
    public float numBullet; //íeÇÃêîéö
    // Start is called before the first frame update
    void Start()
    {
        gameM = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();

        numBullet = gameM.BulletNum;
    }

    // Update is called once per frame
    void Update()
    {
        if(numBullet <= 0)
        {
            Destroy(this.gameObject);
        }

        rb.velocity = new Vector2(0,speed);
    }
}
