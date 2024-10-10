using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    bool hit = false;
    [SerializeField] int power;
    int counter = 0;
    private string objName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (power <= 0)
        {
            Destroy(gameObject);
        }

        if (hit)
        {
            if(objName == "enemy")
            {
                counter++;
                if (counter >= 144)
                {
                    power -= 1;
                    counter = 0;
                }
            }
        }
        else
        {
            transform.position += new Vector3(0, 1.0f, 0) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        objName = collision.gameObject.name;
        hit = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        objName = "";
        hit = false;
    }
}
