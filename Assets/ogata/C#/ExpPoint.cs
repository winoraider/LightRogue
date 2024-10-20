using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ExpPoint : MonoBehaviour
{

    [SerializeField]
    private GameObject ExpPos;

    private float forcePow;

    Rigidbody2D rb;
    private float veloX;

    [SerializeField]
    Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        veloX = Random.Range(-5, 5);
        rb.velocity = new Vector2(veloX,8);
    }

    // Update is called once per frame
    void Update()
    {
        forcePow += 0.01f;

        if (transform.position.y  <  ExpPos.transform.position.y) {
           force = new Vector2(0, forcePow);
            Debug.Log("â∫Ç…à⁄ìÆ");
            rb.AddForce(force);
        }else if (transform.position.y > ExpPos.transform.position.y)
        {
            force = new Vector2(0, -forcePow);
            Debug.Log("è„Ç…à⁄ìÆ");
            rb.AddForce(force);
        }
        if (transform.position.x > ExpPos.transform.position.x)
        {
            force = new Vector2(-forcePow, 0);
            Debug.Log("ç∂Ç…à⁄ìÆ");
            rb.AddForce(force);
        }
        else if (transform.position.x < ExpPos.transform.position.x)
        {
             force = new Vector2(forcePow, 0);
            Debug.Log("âEÇ…à⁄ìÆ");
            rb.AddForce(force);
        }
       
    }
}
