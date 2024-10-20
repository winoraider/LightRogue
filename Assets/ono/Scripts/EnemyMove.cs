using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rb;

    EXPbar expbar;

    [SerializeField]float force;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        expbar = FindObjectOfType<EXPbar>();
        
    }
    private void Update()
    {
        rb.velocity = new Vector2(0, force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("‚ ‚½‚Á‚½");
            Destroy(this.gameObject);
        }

    }
    private void OnDestroy()
    {
        expbar.nowExp += 1;
    }
}
