using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    bool hit = false;
    [SerializeField] int power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
        }
        else
        {
            transform.position -= new Vector3(0, 1.0f, 0) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hit = false;
    }
}
