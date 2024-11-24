using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOutEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Bullet>())
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
