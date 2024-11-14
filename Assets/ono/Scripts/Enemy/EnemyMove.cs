using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    GameManager gameM; //���`��������
    Rigidbody2D rb;

    EXPbar expbar;

    [SerializeField]float force;
    [SerializeField] private GameObject EXPPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        expbar = FindObjectOfType<EXPbar>();
        gameM = FindObjectOfType<GameManager>(); //���`��������
        
    }
    private void Update()
    {
        if (gameObject.tag == "Boss" &&gameM.KnockBack)
        {
            rb.velocity = new Vector2(0, 10f);
            return;
        }
        else if (gameM.KnockBack)
        {
            rb.velocity = new Vector2(0, 20f);
            return;
        }
        if (gameM.SlowTimer)�@//���`��������
        {
            rb.velocity = new Vector2(0, force * 0.8f);
        }
        else
        {
            rb.velocity = new Vector2(0, force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("��������");
            Destroy(this.gameObject);
        }

    }
    private void OnDestroy()
    {
        Instantiate(EXPPoint,transform.position, Quaternion.identity);�@//���`�������� 
        if (gameObject.tag == "Boss")
        {
            gameM.RelicOb.SetActive(true);
        }
    }
}
