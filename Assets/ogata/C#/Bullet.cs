using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gameM;


    BulletBehind tmpColor;

    [SerializeField]
    private GameObject ObjectColor;

    [SerializeField]
    private float speed;
    public float numBullet; //íeÇÃêîéö

    [SerializeField]
    private TextMeshProUGUI numText;

    public bool isRed = false;
    public bool isGreen = false;
    public bool isBlue = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.GetComponent<BulletBehind>())
            {
            collision.gameObject.GetComponent<BulletBehind>().tmpNum(numBullet);
            collision.gameObject.GetComponent<BulletBehind>().tmpColor(isRed,isGreen,isBlue);
                Destroy(this.gameObject);
            }

            
        
    }


    // Start is called before the first frame update
    void Start()
    {
        gameM = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();

        isRed = gameM.isRed;
        isGreen = gameM.isGreen;
        isBlue = gameM.isBlue;

        numBullet = gameM.BulletNum;
    }

    // Update is called once per frame
    void Update()
    {
        ThisColor();
        numText.text = "" + numBullet;


        if(numBullet <= 0)
        {
            Destroy(this.gameObject);
        }

        rb.velocity = new Vector2(0,speed);
    }

    private void IsRed()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
    }

    private void IsGreen()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
    }

    private void IsBlue()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);
    }

    private void IsYellow()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);
    }

    private void IsMagenta()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1);
    }
    private void IsCyan()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1, 1);
    }

    private void IsWhite()
    {
        ObjectColor.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    private void ThisColor()
    {
        if (isRed && !isGreen && !isBlue)
        {
            IsRed();
        }
        else if (!isRed && isGreen && !isBlue)
        {
            IsGreen();
        }
        else if (!isRed && !isGreen && isBlue)
        {
            IsBlue();
        }
        else if (isRed && isGreen && !isBlue)
        {
            IsYellow();
        }
        else if (isRed && !isGreen && isBlue)
        {
            IsMagenta();
        }
        else if (!isRed && isGreen && isBlue)
        {
            IsCyan();
        }
        else if (isRed && isGreen && isBlue)
        {
            IsWhite();
        }
        else
        {
            ObjectColor.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        }
    }
}
